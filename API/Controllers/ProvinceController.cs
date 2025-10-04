using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProvinceController(IProvinceRepository repo): BaseApiController
    {
        [HttpGet("{regionCode}")]
        public async Task<ActionResult<IReadOnlyList<ProvinceDto>>> GetProvinces(string regionCode)
        {
            var response = await repo.GetProvinces(regionCode);

            return Ok(response);
        }
    }
}
