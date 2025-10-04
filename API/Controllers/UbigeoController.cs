using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UbigeoController(IUbigeoRepository repo): BaseApiController
    {
        [HttpGet("{provinceCode}")]
        public async Task<ActionResult<IReadOnlyList<UbigeoDto>>> GetUbigeos(string provinceCode)
        {
            var response = await repo.GetUbigeos(provinceCode);

            return Ok(response);
        }
    }
}
