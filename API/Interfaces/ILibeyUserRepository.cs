using API.Dtos;

namespace API.Interfaces
{
    public interface ILibeyUserRepository
    {
        Task<IReadOnlyList<LibeyUserDto>> GetLibeyUsers();
        Task<ResponseDto> InsertLibeyUser(LibeyUserInsertDto request);
        Task<ResponseDto> UpdateLibeyUser(LibeyUserUpdateDto request);
        Task<ResponseDto> DeleteLibeyUser(string id);
    }
}
