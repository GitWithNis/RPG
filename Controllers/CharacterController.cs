using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Dtos;
using RPG.Dtos.Characters;
using RPG.Services.CharacterService;

namespace RPG.Controllers
{
    [ApiController]
    [Authorize]
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<GetCharacterDto>>> GetCharacterById(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult<ApiResponse<GetCharacterDto>>> AddCharacter(AddCharacterDto request){
            return Ok(await _characterService.AddCharacter(request));
        }

        [HttpPut("update")]
        public async Task<ActionResult<ApiResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto request){
            return Ok(await _characterService.UpdateCharacter(request));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<List<GetCharacterDto>>>> DeleteCharacter(int id){
            return Ok(await _characterService.DeleteCharacter(id));
        }

        [HttpPut("armor/equip")]
        public async Task<ActionResult<ApiResponse<List<GetCharacterDto>>>> EquipArmor(EquipArmorDto request){
            return Ok(await _characterService.EquipArmor(request));
        }

        [HttpPut("armor/remove")]
        public async Task<ActionResult<ApiResponse<List<GetCharacterDto>>>> RemoveArmor(RemoveArmorDto request){
            return Ok(await _characterService.RemoveArmor(request));
        }
    }
}