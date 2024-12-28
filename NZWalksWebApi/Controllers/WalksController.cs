using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZWalksWebApi.DTO;
using NZWalksWebApi.Interface;
using NZWalksWebApi.Models.Domains;

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
    }
}
