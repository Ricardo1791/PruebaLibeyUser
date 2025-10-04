using API.Context;
using API.Dtos;
using API.Interfaces;
using Dapper;

namespace API.Repositories
{
    public class ProvinceRepository(DapperContext _context) : IProvinceRepository
    {
        public async Task<IReadOnlyList<ProvinceDto>> GetProvinces(string RegionCode)
        {
            var query = "exec pa_sel_province @p_regionCode";

            using var connection = _context.CreateConnection();
            var respuesta = await connection.QueryAsync<ProvinceDto>(query, new
            {
                p_regionCode = RegionCode,
            });

            return respuesta.ToList();
        }
    }
}
