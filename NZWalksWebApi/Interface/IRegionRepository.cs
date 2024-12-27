using NZWalksWebApi.DTO;
using NZWalksWebApi.Models.Domains;

namespace NZWalksWebApi.Interface
{
    public interface IRegionRepository
    {
        Task<List<RegionDto>> GetAll();
        Task<RegionDto> GetById(Guid Id);
        Task<Region> PostRegion(Region region);
        Task<RegionDto> DeleteRegion(Guid Id);
        Task<Region> UpdatRegion(Region region);
    }
}
