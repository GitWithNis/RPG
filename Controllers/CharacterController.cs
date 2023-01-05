using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG.Dtos;
using RPG.Services.CharacterService;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet()]
        public async Task<ActionResult<ApiResponse<List<GetCharacterDto>>>> GetAllCharacters(){
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<ApiResponse<GetCharacterDto>>> GetCharacterById(int Id){
            return Ok(await _characterService.GetCharacterById(Id));
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ApiResponse<GetCharacterDto>>> AddCharacter(AddCharacterDto request){
            return Ok(await _characterService.AddCharacter(request));
        }
    }
}