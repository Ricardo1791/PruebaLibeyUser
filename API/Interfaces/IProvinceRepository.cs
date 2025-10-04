using API.Dtos;

namespace API.Interfaces
{
    public interface IProvinceRepository
    {
        Task<IReadOnlyList<ProvinceDto>> GetProvinces(string RegionCode);
    }
}
