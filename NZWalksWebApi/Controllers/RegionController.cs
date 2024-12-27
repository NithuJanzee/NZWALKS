using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksWebApi.Data;
using NZWalksWebApi.DTO;
using NZWalksWebApi.Interface;
using NZWalksWebApi.Models.Domains;

namespace NZWalksWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }




        //Get All
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var data = await _regionRepository.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _regionRepository.GetById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion(RegionRequestDTO requestDTO)
        {
            var data = _mapper.Map<Region>(requestDTO);
            await _regionRepository.PostRegion(data);
            var response = _mapper.Map<RegionDto>(data);
            return CreatedAtAction(nameof(GetById), new { id = data.Id }, response);
        }

        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> UpdateRegion(Guid Id, RegionRequestDTO regionRequestDTO)
        {
            var DataExits = await _regionRepository.GetById(Id);
            if (DataExits == null) return NotFound();

            var updatedRegion = new Region
            {
                Id = Id,
                Code = regionRequestDTO.Code,
                FullName = regionRequestDTO.FullName,
                ImageUrl = regionRequestDTO.ImageUrl,
            };
             var update =  await _regionRepository.UpdatRegion(updatedRegion);
            var response = _mapper.Map<Region>(update);
            return Ok(response);
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> DeleteById(Guid Id)
        {
            var data = await _regionRepository.DeleteRegion(Id);
            return Ok(data);
        }

    }
}
