using API.Context;
using API.Dtos;
using API.Interfaces;
using Dapper;

namespace API.Repositories
{
    public class DocumentTypeRepository(DapperContext _context) : IDocumentTypeRepository
    {
        public async Task<IReadOnlyList<DocumentTypeDto>> getDocumentTypes()
        {
            var query = "exec pa_sel_documentType";

            using var connection = _context.CreateConnection();
            var respuesta = await connection.QueryAsync<DocumentTypeDto>(query);

            return respuesta.ToList();
        }
    }
}
