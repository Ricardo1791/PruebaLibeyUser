import { Component, inject, OnInit, signal } from '@angular/core';
import { LibeyuserService } from '../services/libeyuser-service';
import { LibeyUser, Province, Region, TipoDocumento, Ubigeo } from '../models/libeyUser';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  protected tipoDocumentos = signal<TipoDocumento[]>([]);
  protected regiones = signal<Region[]>([]);
  protected provincias = signal<Province[]>([]);
  protected ubigeos = signal<Ubigeo[]>([]);
  protected libeyUserList = signal<LibeyUser[]>([]);
  protected libeyUserService = inject(LibeyuserService);
  protected fb = inject(FormBuilder);
  protected libeyUserForm: FormGroup;
  protected update = signal(false);

  constructor(){
    this.libeyUserForm = this.fb.group({
      documentNumber: ['', [Validators.required]],
      documentTypeId: [0, [Validators.min(1)]],
      name: ['', [Validators.required]],
      fathersLastName: ['', [Validators.required]],
      mothersLastName: ['', [Validators.required]],
      address: ['', [Validators.required]],
      ubigeoCode: ['', [Validators.required]],
      provinceCode: ['', [Validators.required]],
      regionCode: ['', [Validators.required]],
      phone: ['', [Validators.required]],
      email: ['', [Validators.email]],
      password: ['', [Validators.required]]
    })
  }
  
  ngOnInit(): void {
    this.listLibeyUser();
    this.libeyUserService.getDocumentTypes().subscribe({
      next: data => {
        this.tipoDocumentos.set(data);
      }
    });
    this.libeyUserService.getRegions().subscribe({
      next: data => {
        this.regiones.set(data);
      }
    })
  }


  listLibeyUser(){
    this.libeyUserService.getLibeyUsers().subscribe({
      next: data => {
        this.libeyUserList.set(data);
      }
    })
  }

  agregar(ref: HTMLDialogElement){
    this.update.set(false);
    ref.showModal();
    this.libeyUserForm.reset();
    this.libeyUserForm.get('ubigeoCode')?.setValue('');
    this.libeyUserForm.get('provinceCode')?.setValue('');
    this.libeyUserForm.get('regionCode')?.setValue('');
    this.libeyUserForm.get('documentTypeId')?.setValue(0);
    this.provincias.set([]);
    this.ubigeos.set([]);
  }

  cambioRegion(e: any){
    this.libeyUserForm.get('ubigeoCode')?.setValue('');
    this.libeyUserForm.get('provinceCode')?.setValue('');
    this.libeyUserService.getProvinces(e.target.value).subscribe({
      next: data => {
        this.provincias.set(data);
      }
    })
  }

  cambioProvincia(e: any){
    this.libeyUserForm.get('ubigeoCode')?.setValue('');
    this.libeyUserService.getUbigeos(e.target.value).subscribe({
      next: data => {
        this.ubigeos.set(data);
      }
    })
  }

  guardar(modal: HTMLDialogElement){
    const formulario: LibeyUser = this.libeyUserForm.value;

    if (!this.update()){
      this.libeyUserService.insertLibeyUser(formulario).subscribe({
        next: data => {
          alert(data.message);
          this.listLibeyUser();
          modal.close();
        }
      })

    }else{
      this.libeyUserService.updateLibeyUser(formulario).subscribe({
        next: data => {
          alert(data.message);
          this.listLibeyUser();
          modal.close();
        }
      })
    }
  }

  editar(model: any, modal: HTMLDialogElement){
    this.update.set(true);

    this.libeyUserService.getProvinces(model.regionCode).subscribe({
      next: data => {
        this.provincias.set(data);
      }
    })
    this.libeyUserService.getUbigeos(model.provinceCode).subscribe({
      next: data => {
        this.ubigeos.set(data);
      }
    })
    this.libeyUserForm.patchValue(model);
    modal.showModal();
  }

  anular(documentNumber: string){
    if (confirm('¿Desea eliminar el registro?')){
      this.libeyUserService.deleteLibeyUser(documentNumber).subscribe({
        next: data => {
          alert(data.message);
          this.listLibeyUser();
        }
      })
    }
  }
}
