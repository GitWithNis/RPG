using Microsoft.AspNetCore.Mvc;
using RPG.Dtos;
using RPG.Dtos.Characters;
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

        [HttpPost("add")]
        public async Task<ActionResult<ApiResponse<GetCharacterDto>>> AddCharacter(AddCharacterDto request){
            return Ok(await _characterService.AddCharacter(request));
        }

        [HttpPut("update")]
        public async Task<ActionResult<ApiResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto request){
            return Ok(await _characterService.UpdateCharacter(request));
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<ApiResponse<List<GetCharacterDto>>>> DeleteCharacter(int Id){
            return Ok(await _characterService.DeleteCharacter(Id));
        }
    }
}