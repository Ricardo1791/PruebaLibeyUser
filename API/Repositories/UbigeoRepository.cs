using API.Context;
using API.Dtos;
using API.Interfaces;
using Dapper;

namespace API.Repositories
{
    public class UbigeoRepository(DapperContext _context) : IUbigeoRepository
    {
        public async Task<IReadOnlyList<UbigeoDto>> GetUbigeos(string ProvinceCode)
        {
            var query = "exec pa_sel_ubigeo @p_provinceCode";

            using var connection = _context.CreateConnection();
            var respuesta = await connection.QueryAsync<UbigeoDto>(query, new
            {
                p_provinceCode = ProvinceCode,
            });

            return respuesta.ToList();
        }
    }
}
