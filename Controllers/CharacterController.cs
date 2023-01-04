using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        [HttpGet("test")]
        public async Task<ActionResult<int>> TestFunc(){
            return Ok(69);
        }
    }
}