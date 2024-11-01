﻿using api.DTOs.Motorcycle;
using api.Helpers.Queries;
using api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController(IMotorcyclesService motorcyclesService) : ControllerBase
    {
        private readonly IMotorcyclesService _motorcyclesService = motorcyclesService;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MotorcycleQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDtos = await _motorcyclesService.GetAllAsync(query);

            return Ok(getDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDto = await _motorcyclesService.GetByIdAsync(id);

            return getDto == null ? NotFound() : Ok(getDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MotorcyclePostDTO postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDto = await _motorcyclesService.CreateAsync(postDto);

            return getDto == null ? NotFound() : Ok(getDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] MotorcyclePutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDto = await _motorcyclesService.UpdateAsync(id, putDto);

            return getDto == null ? NotFound() : Ok(getDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDto = await _motorcyclesService.DeleteAsync(id);

            return getDto == null ? NotFound() : NoContent();
        }
    }
}
