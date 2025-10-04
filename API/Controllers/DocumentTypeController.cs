using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DocumentTypeController(IDocumentTypeRepository repo): BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DocumentTypeDto>>> GetDocumentType()
        {
            var response = await repo.getDocumentTypes();

            return Ok(response);
        }
    }
}
