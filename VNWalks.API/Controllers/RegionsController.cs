using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VNWalks.API.Data;
using VNWalks.API.Models.Domain;
using VNWalks.API.Models.DTO;
using VNWalks.API.Repositories;

namespace VNWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        // GET all regions
        // GET: https://localhost:port/api/Regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomainModel = await _regionRepository.GetAllAsync();
            // Map bằng tay
            //var regionsDto = new List<RegionDto>();
            //foreach (var regionDomainModel in regionsDomainModel)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = regionDomainModel.Id,
            //        Code = regionDomainModel.Code,
            //        Name = regionDomainModel.Name,
            //        RegionImageUrl = regionDomainModel.RegionImageUrl

            //    });
            //}

            // Automapper
            var regionsDto = _mapper.Map<List<RegionDto>>(regionsDomainModel);

            return Ok(regionsDto);
        }

        // GET region by id
        // GET: https://localhost:port/api/Regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.GetByIdAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);
        }

        // POST to create new region
        // POST: https://localhost:port/api/Regions
        // https://statoids.com/uvn.html
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        // Update region
        // PUT: https://localhost:port/api/Regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);
            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);
        }
        // Delete region
        // DELETE: https://localhost:port/api/Regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
