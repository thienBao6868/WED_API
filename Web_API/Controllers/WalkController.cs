using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Models.Domain;
using Web_API.Models.DTO.RequestDTO;
using Web_API.Models.DTO.ResponseDTO;
using Web_API.Repositories.IRepository;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private IMapper _mapper;

        public WalkController(IWalkRepository walkRepository,IMapper mapper)
        {
            this._walkRepository = walkRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody]AddWalkDTO addWalkDTO)
        {
            // Map addWalkDTO to Walk
            var walkDomain = _mapper.Map<Walk>(addWalkDTO);

            walkDomain = await _walkRepository.createAsync(walkDomain);

            // map walkDomain to Walk

            return Ok(_mapper.Map<WalkDTO>(walkDomain));

        }
    }
}
