using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LibeyUserController(ILibeyUserRepository repo): BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<LibeyUserDto>>> GetLibeyUsers()
        {
            var lista = await repo.GetLibeyUsers();

            return Ok(lista);
        }

        [HttpPost("update")]
        public async Task<ActionResult<ResponseDto>> UpdateLibeyUser([FromBody] LibeyUserUpdateDto model)
        {
            var response = await repo.UpdateLibeyUser(model);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto>> DeleteLibeyUser(string id)
        {
            var response = await repo.DeleteLibeyUser(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> InsertLibeyUser([FromBody] LibeyUserInsertDto model)
        {
            var response = await repo.InsertLibeyUser(model);
            return Ok(response);
        }
    }
}
