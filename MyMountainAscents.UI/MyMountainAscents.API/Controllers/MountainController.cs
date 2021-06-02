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
    public class MountainController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MountainController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetAllMountains()
            => Ok(_appDbContext.Mountains);

        [HttpGet("{guid}")]
        public IActionResult GetMountainByGuid(Guid guid)
        {
            Mountain mountain = _appDbContext.Mountains
                .Include(m => m.Ascents)
                .ToList()
                .SingleOrDefault(m => m.Id == guid);

            if (mountain != null)
                return Ok(mountain);

            return NotFound("No mountain found");
        }

        [HttpPost]
        public async Task<IActionResult> AddMountain([FromBody] Mountain mountain)          
        {
            if (mountain == null)
                return BadRequest("Het meegestuurde object is leeg");

            _appDbContext.Mountains.Add(mountain);
            await _appDbContext.SaveChangesAsync();

            return Created("Mountain", mountain);
        }
    }
}
