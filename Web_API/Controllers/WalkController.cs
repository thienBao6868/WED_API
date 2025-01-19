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

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var walksDomain = await _walkRepository.getAllAsync();

            // map walksDomain to walksDTO

            return Ok(_mapper.Map<List<WalkDTO>>(walksDomain));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            var walkDomain = await _walkRepository.getByIdAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }
            // map walk to walkDTO
            return Ok(_mapper.Map<WalkDTO>(walkDomain));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] AddWalkDTO addWalkDTO)
        {
            // map addWalkDTO to walkDomain
            var walkDomain = _mapper.Map<Walk>(addWalkDTO);

            walkDomain = await _walkRepository.updateAsync(id, walkDomain);
            if (walkDomain == null)
            {
                return NotFound();
            }

            // map walkDomain to walkDTO
            return Ok(_mapper.Map<WalkDTO>(walkDomain));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            var walkDomain = await _walkRepository.deleteAsync(id);
            if(walkDomain == null) return NotFound();

            // map walkDomain to walkDomainDTO
            return Ok(_mapper.Map<WalkDTO>(walkDomain));
        }
    }
}
