using NZWalksWebApi.Models.Domains;

namespace NZWalksWebApi.Interface
{
    public interface IwalksRepository
    {
        Task<Walk> CreateWalk(Walk walk);
    }
}
