using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Web_API.Data;
using Web_API.Models.Domain;
using Web_API.Models.DTO.RequestDTO;
using Web_API.Models.DTO.ResponseDTO;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AppApiDbContext _appApiContext;

        public RegionsController(AppApiDbContext appApiContext)
        {
            this._appApiContext = appApiContext;
        }

        [HttpGet]
        public IActionResult GetAll() {
            // Get Region in DataBase
            var regionsDomain = _appApiContext.Regions.ToList();

            // Map Data to RegionDTO
            var regionsDTO = new List<RegionDTO>();

            foreach (var region in regionsDomain) {

                regionsDTO.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                });
            }
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute]Guid id) {
            //var region = _appApiContext.Regions.Find(id);
            var regionDomain = _appApiContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomain == null) {
                return NotFound();
            }

            // map Data To RegionDTO
            var regionDTO = new RegionDTO()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDTO);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddRegionDTO addRegionDTO)
        {
            var regionDomain = new Region
            {
                Code = addRegionDTO.Code,
                Name = addRegionDTO.Name,
                RegionImageUrl = addRegionDTO.RegionImageUrl
            };

            _appApiContext.Regions.Add(regionDomain);
            _appApiContext.SaveChanges();


            // map to RegionDTO

            var regionDTO = new RegionDTO
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById),new {id = regionDTO.Id}, regionDTO);


        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            var regionDomain = _appApiContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map Dto to Domain
            regionDomain.Name = updateRegionDTO.Name;
            regionDomain.Code = updateRegionDTO.Code;
            regionDomain.RegionImageUrl = updateRegionDTO.RegionImageUrl;

            _appApiContext.SaveChanges();

            // Convert Domain to DTO
            var regionDto = new RegionDTO
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(regionDto);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionDomain = _appApiContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomain == null) return NotFound();

            _appApiContext.Regions.Remove(regionDomain);
            _appApiContext.SaveChanges();

            // Convert Domain to DTO
            var regionDto = new RegionDTO
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(regionDto);
        }

    }
}