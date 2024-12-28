using Microsoft.EntityFrameworkCore;
using NZWalksWebApi.Data;
using NZWalksWebApi.DTO;
using NZWalksWebApi.Interface;
using NZWalksWebApi.Models.Domains;

namespace NZWalksWebApi.Repository
{
    public class SqlWalkRepository : IwalksRepository
    {
        private readonly NzWalksDbContext _dbContext;

        public SqlWalkRepository(NzWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Walk> CreateWalk(Walk walk)
        {
            await _dbContext.walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalks()
        {
            return await _dbContext.walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk> GetById(Guid Id)
        {
            var Data = await _dbContext.walks.
                Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (Data == null) throw new Exception("Not Found");

            return Data;
        }


        public async Task<Walk> Update (Guid id , Walk walk)
        {
            var findData = await _dbContext.walks.FirstOrDefaultAsync(x =>x.Id == id);
            if (findData == null) throw new Exception("Not Found");

            findData.Name = walk.Name;
            findData.WalkImageUrl = walk.WalkImageUrl;
            findData.Description = walk.Description;
            findData.lengthInKm = walk.lengthInKm;
            findData.RegionID = walk.RegionID;
            findData.DifficultyID = walk.DifficultyID;
            await _dbContext.SaveChangesAsync();

            return findData;
        }
    }
}
