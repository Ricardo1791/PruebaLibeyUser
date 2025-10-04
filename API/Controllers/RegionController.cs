using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RegionController(IRegionRepository repo): BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RegionDto>>> GetRegions()
        {
            var response = await repo.GetRegions();

            return Ok(response);
        }
    }
}
