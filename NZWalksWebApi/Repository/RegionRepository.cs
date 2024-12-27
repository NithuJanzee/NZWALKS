using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NZWalksWebApi.Data;
using NZWalksWebApi.DTO;
using NZWalksWebApi.Interface;
using NZWalksWebApi.Models.Domains;

namespace NZWalksWebApi.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext _context;
       private readonly IMapper _mapper;

        public RegionRepository(NzWalksDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get All 
        public async Task<List<RegionDto>> GetAll()
        {
            var AllRegion = await _context.regions.ToListAsync();
            var regionDTO = _mapper.Map<List<RegionDto>>(AllRegion);
            return regionDTO;

        }

        //Get By Id
        public async Task<RegionDto> GetById(Guid Id)
        {
            var Region = await _context.regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (Region == null) throw new Exception("Not Found");
           
            return _mapper.Map<RegionDto>(Region);
        }

        //Post
        public async Task<Region> PostRegion(Region region)
        {
            var Post = await _context.regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return Post.Entity;
        }

        //Delete
        public async Task<RegionDto> DeleteRegion(Guid Id)
        {
            var Region = await _context.regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (Region == null) throw new Exception("Not Found");
            _context.Remove(Region);
            await _context.SaveChangesAsync();
            return _mapper.Map<RegionDto>(Region);
        }

        //update
        public async Task<Region> UpdatRegion(Region region)
        {
            var update = await _context.regions.FirstOrDefaultAsync(x => x.Id == region.Id);
            if (update == null) throw new Exception("Not Found");
            update.FullName = region.FullName;
            update.Code = region.Code;
            update.ImageUrl = region.ImageUrl;
             _context.Update(update);
            await _context.SaveChangesAsync();
            return region;
        }
    }
}
