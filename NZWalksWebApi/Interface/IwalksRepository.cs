using NZWalksWebApi.DTO;
using NZWalksWebApi.Models.Domains;

namespace NZWalksWebApi.Interface
{
    public interface IwalksRepository
    {
        Task<Walk> CreateWalk(Walk walk);
        Task<List<Walk>> GetAllWalks();
        Task<Walk> GetById(Guid Id);
        Task<Walk> Update(Guid id, Walk walk);
        Task<Walk> DeleteWalk(Guid ID);
    }
}
