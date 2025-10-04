using API.Dtos;

namespace API.Interfaces
{
    public interface IRegionRepository
    {
        Task<IReadOnlyList<RegionDto>> GetRegions();
    }
}
