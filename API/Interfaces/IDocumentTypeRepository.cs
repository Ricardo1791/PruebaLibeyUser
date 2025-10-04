using API.Dtos;

namespace API.Interfaces
{
    public interface IDocumentTypeRepository
    {
        Task<IReadOnlyList<DocumentTypeDto>> getDocumentTypes();
    }
}
