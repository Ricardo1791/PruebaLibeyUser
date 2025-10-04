use [LibeyTechnicalTest]
go

create proc pa_sel_LibeyUser as
begin


select DocumentNumber,
	   d.DocumentTypeDescription,
	   d.DocumentTypeId,
	   Name,
	   FathersLastName,
	   MothersLastName,
	   Address,
	   u.UbigeoDescription,
	   p.ProvinceDescription,
	   r.RegionDescription,
	   u.UbigeoCode,
	   p.ProvinceCode,
	   r.RegionCode,
	   Phone,
	   Email,
	   Password
From LibeyUser l
join DocumentType d on l.DocumentTypeId = d.DocumentTypeId
join Ubigeo u on l.UbigeoCode = u.UbigeoCode
join Province p on u.ProvinceCode = p.ProvinceCode
join Region r on p.RegionCode = r.RegionCode
where l.Active = 1


end
go


create proc pa_ins_LibeyUser(@p_DocumentNumber varchar(100), @p_DocumentTypeId int, @p_Name varchar(100), @p_fLastName varchar(100), @p_mLastName varchar(100), @p_Address varchar(100), @p_Ubigeo varchar(100), @p_Phone varchar(100), @p_Email varchar(100), @p_Password varchar(100)) as
begin

declare @respuesta table(
success bit,
message varchar(1000)
)	


BEGIN TRY
        BEGIN TRANSACTION;

		if (not exists (select 1 from LibeyUser where DocumentNumber = @p_DocumentNumber))
		begin

			insert into LibeyUser (DocumentNumber, DocumentTypeId, Name, FathersLastName, MothersLastName, Address, UbigeoCode, Phone, Email, Password, Active)
			values (@p_DocumentNumber,@p_DocumentTypeId, @p_Name, @p_fLastName, @p_mLastName, @p_Address, @p_Ubigeo, @p_Phone, @p_Email, @p_Password, 1)


			insert into @respuesta values (1, 'Registro exitoso')
		end
		else
		begin
			
			insert into @respuesta values (0, 'Document Number ya existe')


		end
		

		COMMIT TRANSACTION;
END TRY
BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        insert into @respuesta values (0, @ErrorMessage)


END CATCH


select * from @respuesta


end
go



create proc pa_upd_LibeyUser(@p_DocumentNumber varchar(100), @p_DocumentTypeId int, @p_Name varchar(100), @p_fLastName varchar(100), @p_mLastName varchar(100), @p_Address varchar(100), @p_Ubigeo varchar(100), @p_Phone varchar(100), @p_Email varchar(100), @p_Password varchar(100)) as
begin

declare @respuesta table(
success bit,
message varchar(1000)
)	


BEGIN TRY
        BEGIN TRANSACTION;

		update LibeyUser set DocumentTypeId = @p_DocumentTypeId, Name = @p_Name, FathersLastName = @p_fLastName,
		MothersLastName = @p_mLastName, Address = @p_Address, UbigeoCode = @p_Ubigeo, Phone = @p_Phone, Email = @p_Email, Password = @p_Password
		where DocumentNumber = @p_DocumentNumber
		

		insert into @respuesta values (1, 'Actualizacion exitosa')
		

		COMMIT TRANSACTION;
END TRY
BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        insert into @respuesta values (0, @ErrorMessage)


END CATCH

select * from @respuesta


end
go


create proc pa_del_LibeyUser(@p_DocumentNumber varchar(20))
as
begin

declare @respuesta table(
success bit,
message varchar(1000)
)	


BEGIN TRY
        BEGIN TRANSACTION;

		update LibeyUser set Active = 0 
		where DocumentNumber = @p_DocumentNumber
		

		insert into @respuesta values (1, 'Anulacion exitosa')
		

		COMMIT TRANSACTION;
END TRY
BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        insert into @respuesta values (0, @ErrorMessage)


END CATCH

select * from @respuesta


end
go

create proc pa_sel_region as
begin


select RegionCode,
	   RegionDescription
From Region


end
go


create proc pa_sel_province(@p_regionCode char(2)) as
begin

select ProvinceCode,
	   ProvinceDescription
from Province
where RegionCode = @p_regionCode

end
go


create proc pa_sel_ubigeo (@p_provinceCode char(4))
as
begin

select UbigeoCode,
	    UbigeoDescription
from Ubigeo 
where ProvinceCode = @p_provinceCode


end
go

create proc pa_sel_documentType
as
begin


select DocumentTypeId,
	   DocumentTypeDescription
from DocumentType


end
go