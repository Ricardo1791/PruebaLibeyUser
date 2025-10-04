import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { TipoDocumento, LibeyUser, Province, Region, Ubigeo } from '../models/libeyUser';

@Injectable({
  providedIn: 'root'
})
export class LibeyuserService {
   
  private url = 'http://localhost:5000/api/';
  private http = inject(HttpClient);

  getDocumentTypes(){
    return this.http.get<TipoDocumento[]>(this.url + 'DocumentType');
  }

  getRegions(){
    return this.http.get<Region[]>(this.url + 'Region');
  }

  getProvinces(regionCode: string){
    return this.http.get<Province[]>(this.url + 'Province/' + regionCode)
  }

  getUbigeos(provinceCode: string){
    return this.http.get<Ubigeo[]>(this.url + 'Ubigeo/' + provinceCode);
  }

  getLibeyUsers(){
    return this.http.get<LibeyUser[]>(this.url + 'LibeyUser');
  }

  insertLibeyUser(model: LibeyUser){
    return this.http.post<any>(this.url + 'LibeyUser', model);
  }

  updateLibeyUser(model: LibeyUser){
    return this.http.post<any>(this.url + 'LibeyUser/update', model);
  }

  deleteLibeyUser(documentNumber: string){
    return this.http.delete<any>(this.url + 'LibeyUser/'+ documentNumber);
  }

}
