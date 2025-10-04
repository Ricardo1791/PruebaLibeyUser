using API.Context;
using API.Dtos;
using API.Interfaces;
using Dapper;
using System.Net;
using System.Xml.Linq;

namespace API.Repositories
{
    public class LibeyUserRepository(DapperContext _context) : ILibeyUserRepository
    {
        public async Task<ResponseDto> DeleteLibeyUser(string id)
        {
            var query = "exec pa_del_LibeyUser @p_DocumentNumber";

            using var connection = _context.CreateConnection();
            var respuesta = await connection.QueryAsync<ResponseDto>(query, new
            {
                p_DocumentNumber = id
            });

            return respuesta.FirstOrDefault();
        }

        public async Task<IReadOnlyList<LibeyUserDto>> GetLibeyUsers()
        {
            var query = "exec pa_sel_LibeyUser";

            using var connection = _context.CreateConnection();
            var respuesta = await connection.QueryAsync<LibeyUserDto>(query);

            return respuesta.ToList();
        }

        public async Task<ResponseDto> InsertLibeyUser(LibeyUserInsertDto request)
        {
            var query = "exec pa_ins_LibeyUser @p_DocumentNumber, @p_DocumentTypeId, @p_Name, @p_fLastName, @p_mLastName, @p_Address, @p_Ubigeo, @p_Phone, @p_Email, @p_Password";

            using var connection = _context.CreateConnection();
            var respuesta = await connection.QueryAsync<ResponseDto>(query, new
            {
                p_DocumentNumber = request.DocumentNumber,
                p_DocumentTypeId = request.DocumentTypeId,
                p_Name = request.Name,
                p_fLastName = request.FathersLastName,
                p_mLastName = request.MothersLastName,
                p_Address = request.Address,
                p_Email = request.Email,
                p_Ubigeo = request.UbigeoCode,
                p_Phone = request.Phone,
                p_Password = request.Password,
            });

            return respuesta.FirstOrDefault();
        }

        public async Task<ResponseDto> UpdateLibeyUser(LibeyUserUpdateDto request)
        {
            var query = "exec pa_upd_LibeyUser @p_DocumentNumber, @p_DocumentTypeId, @p_Name, @p_fLastName, @p_mLastName, @p_Address, @p_Ubigeo, @p_Phone, @p_Email, @p_Password";

            using var connection = _context.CreateConnection();
            var respuesta = await connection.QueryAsync<ResponseDto>(query, new
            {
                p_DocumentNumber = request.DocumentNumber,
                p_DocumentTypeId = request.DocumentTypeId,
                p_Name = request.Name,
                p_fLastName = request.FathersLastName,
                p_mLastName = request.MothersLastName,
                p_Address = request.Address,
                p_Email = request.Email,
                p_Ubigeo = request.UbigeoCode,
                p_Phone = request.Phone,
                p_Password = request.Password,
            });

            return respuesta.FirstOrDefault();
        }
    }
}
