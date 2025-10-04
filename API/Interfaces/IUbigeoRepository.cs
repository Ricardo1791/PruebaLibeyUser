using API.Dtos;

namespace API.Interfaces
{
    public interface IUbigeoRepository
    {
        Task<IReadOnlyList<UbigeoDto>> GetUbigeos(string ProvinceCode);
    }
}
