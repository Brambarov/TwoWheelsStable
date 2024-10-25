﻿using api.Data;
using api.Helpers.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MotorcyclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _context.Motorcycles
                .Select(m => m.ToGetDTO())
                .ToListAsync();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var model = await _context.Motorcycles.FindAsync(id);

            if (model == null) return NotFound();

            var dto = model.ToGetDTO();

            return Ok(dto);
        }
    }
}
