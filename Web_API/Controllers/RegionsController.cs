﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Web_API.Data;
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

        public RegionsController(AppApiDbContext appApiContext,IRegionRepository regionRepository)
        {
            this._appApiContext = appApiContext;
            this._regionRepository = regionRepository;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAll() {
            // Get Region in DataBase
            var regionsDomain = await _regionRepository.getAllAsync();

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
        public async Task<IActionResult> GetById([FromRoute]Guid id) {
            //var region = _appApiContext.Regions.Find(id);
            var regionDomain = await _regionRepository.getByIdAsync(id);
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
        public async Task<IActionResult> Create([FromBody] AddRegionDTO addRegionDTO)
        {
            var regionDomain = new Region
            {
                Code = addRegionDTO.Code,
                Name = addRegionDTO.Name,
                RegionImageUrl = addRegionDTO.RegionImageUrl
            };
            regionDomain = await _regionRepository.createAsync(regionDomain);

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
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            // map updateRegionDTO to Region

            var regionDomain = new Region
            {
                Code = updateRegionDTO.Code,
                Name = updateRegionDTO.Name,
                RegionImageUrl = updateRegionDTO.RegionImageUrl
            };


            regionDomain = await _regionRepository.updateAsync(id, regionDomain);

            if(regionDomain == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.deleteAsync(id);

            if (regionDomain == null) return NotFound();
         
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