using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZWalksWebApi.DTO;
using NZWalksWebApi.Interface;
using NZWalksWebApi.Models.Domains;
using System.Reflection.Metadata.Ecma335;

namespace NZWalksWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IwalksRepository _walksRepository;

        public WalksController(IMapper mapper, IwalksRepository walksRepository)
        {
            _mapper = mapper;
            _walksRepository = walksRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostWalks([FromBody] WalkRequestDTO requestDTO)
        {
            //Map dto to domain modal 
            var dataDomainModal = _mapper.Map<Walk>(requestDTO);
            await _walksRepository.CreateWalk(dataDomainModal);

            return Ok(_mapper.Map<WalkDTO>(dataDomainModal));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? filterQuerry,
            [FromQuery] string? SortBy, bool IsAcending, [FromQuery] int pageNumber = 1 , [FromQuery] int pageSize = 15)
        {
            var data = await _walksRepository.GetAllWalks(filterOn , filterQuerry , SortBy , IsAcending, pageNumber ,pageSize);
            return Ok(_mapper.Map<List<WalkDTO>>(data));
        }

        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetByID(Guid Id)
        {
            var data = await _walksRepository.GetById(Id);
            return Ok(_mapper.Map<WalkDTO>(data));
        }

        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> UpdateWalks(Guid Id , WalkRequestDTO dTO)
        {
            var MapData = _mapper.Map<Walk>(dTO);
            var SentData = await _walksRepository.Update(Id,MapData);
            if(SentData == null)return NotFound();

            return Ok(_mapper.Map<WalkDTO>(SentData));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var data = await _walksRepository.DeleteWalk(id);
            return Ok(_mapper.Map<WalkDTO>(data));
        }
    }
}
