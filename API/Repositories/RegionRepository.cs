using API.Context;
using API.Dtos;
using API.Interfaces;
using Dapper;

namespace API.Repositories
{
    public class RegionRepository(DapperContext _context) : IRegionRepository
    {
        public async Task<IReadOnlyList<RegionDto>> GetRegions()
        {
            var query = "exec pa_sel_region";

            using var connection = _context.CreateConnection();
            var respuesta = await connection.QueryAsync<RegionDto>(query);

            return respuesta.ToList();
        }
    }
}
