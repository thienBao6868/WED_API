using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Web_API.Data;
using Web_API.Mappings;
using Web_API.Models.Domain;
using Web_API.Models.DTO.RequestDTO;
using Web_API.Models.DTO.ResponseDTO;
using Web_API.Repositories;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AppApiDbContext _appApiContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(AppApiDbContext appApiContext,IRegionRepository regionRepository, IMapper mapper)
        {
            this._appApiContext = appApiContext;
            this._regionRepository = regionRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAll() {
            // Get Region in DataBase
            var regionsDomain = await _regionRepository.getAllAsync();

            // Map Data to RegionDTO

            return Ok(_mapper.Map<List<RegionDTO>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id) {
            //var region = _appApiContext.Regions.Find(id);
            var regionDomain = await _regionRepository.getByIdAsync(id);
            if (regionDomain == null) {
                return NotFound();
            }

            // map Data To RegionDTO
            return Ok(_mapper.Map<RegionDTO>(regionDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionDTO addRegionDTO)
        {
            var regionDomain = _mapper.Map<Region>(addRegionDTO);
            regionDomain = await _regionRepository.createAsync(regionDomain);

            // map to RegionDTO
            var regionDTO = _mapper.Map<RegionDTO>(regionDomain);

            return CreatedAtAction(nameof(GetById),new {id = regionDTO.Id}, regionDTO);


        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            // map updateRegionDTO to Region
            var regionDomain = _mapper.Map<Region>(updateRegionDTO);
            regionDomain = await _regionRepository.updateAsync(id, regionDomain);
            if(regionDomain == null)
            {
                return NotFound();
            }
            // Convert Domain to DTO
            return Ok(_mapper.Map<RegionDTO>(regionDomain));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.deleteAsync(id);

            if (regionDomain == null) return NotFound();
         
            // Convert Domain to DTO
            var regionDto = _mapper.Map<RegionDTO>(regionDomain);  

            return Ok(regionDto);
        }

    }
}