using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<Walk>> GetAllWalks(string? filterOn = null, string? filterQuerry = null
            , string? sorting = null, bool IsAcending = true, int pageNumber = 1, int pageSize = 15)
        {
            var Walks = _dbContext.walks.Include("Difficulty").Include("Region").AsQueryable();
            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuerry) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    Walks = Walks.Where(x => x.Name.Contains(filterQuerry));
                }
                //else if (filterOn.Equals("lengthInKm", StringComparison.OrdinalIgnoreCase))
                //{
                //    if (double.TryParse(filterQuerry, out double length))
                //    {
                //        Walks = Walks.Where(x => x.lengthInKm == length);
                //    }
                //}
            }
            //sorting
            if (string.IsNullOrWhiteSpace(sorting) == false)
            {
                if (sorting.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    Walks = IsAcending ? Walks.OrderBy(x => x.Name) : Walks.OrderByDescending(x => x.Name);
                }
                else if (sorting.Equals("lengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    Walks = IsAcending ? Walks.OrderBy(x => x.lengthInKm) : Walks.OrderByDescending(x => x.lengthInKm);
                }
            }

            //Pagination
            var SkipPages = (pageNumber - 1) * pageSize;

            return await Walks.Skip(SkipPages).Take(pageSize).ToListAsync();
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


        public async Task<Walk> Update(Guid id, Walk walk)
        {
            var findData = await _dbContext.walks.FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<Walk> DeleteWalk(Guid ID)
        {
            var FindData = await _dbContext.walks.FirstOrDefaultAsync(x => x.Id == ID);
            if (FindData == null) throw new Exception("Not Found yet");
            _dbContext.walks.Remove(FindData);
            await _dbContext.SaveChangesAsync();
            return FindData;
        }
    }
}
