using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMountainAscents.API.Context;
using MyMountainAscents.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AscentController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public AscentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("{guid}")]
        public async Task<IActionResult> AddAscent([FromBody] Ascent ascent, Guid guid)
        {
            if (ascent == null)
                return BadRequest("Het meegestuurde object is leeg");

            Mountain mountain = _appDbContext.Mountains
                .Include(m => m.Ascents)
                .SingleOrDefault(m => m.Id == guid);

            if (mountain == null)
                return NotFound("mountain not found");

            mountain.Ascents.Add(ascent);
            await _appDbContext.SaveChangesAsync();

            return Created("Ascent", ascent);
        }
    }
}
