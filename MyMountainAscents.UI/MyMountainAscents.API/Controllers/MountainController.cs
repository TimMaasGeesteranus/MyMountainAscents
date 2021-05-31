using Microsoft.AspNetCore.Mvc;
using MyMountainAscents.API.Context;
using MyMountainAscents.API.Entities;
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
