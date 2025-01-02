using Microsoft.AspNetCore.Mvc;
using NZWalksWebApi.DTO;
using NZWalksWebApi.Models.Domains;

namespace NZWalksWebApi.Interface
{
    public interface IwalksRepository
    {
        Task<Walk> CreateWalk(Walk walk);
        Task<List<Walk>> GetAllWalks(string? filterOn=null, string? filterQuerry=null,
            string? sorting = null, bool IsAcending = true, int pageNumber = 1, int pageSize = 15);
        Task<Walk> GetById(Guid Id);
        Task<Walk> Update(Guid id, Walk walk);
        Task<Walk> DeleteWalk(Guid ID);
    }
}
