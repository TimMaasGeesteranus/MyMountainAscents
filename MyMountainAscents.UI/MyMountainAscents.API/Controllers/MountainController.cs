using Microsoft.AspNetCore.Mvc;
using MyMountainAscents.API.Context;
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
        public IActionResult GetAllRollen()
            => Ok(_appDbContext.Mountains);
    }
}
