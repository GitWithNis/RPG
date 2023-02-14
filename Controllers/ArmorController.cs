using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Dtos;
using RPG.Dtos.Armors;
using RPG.Services.ArmorService;

namespace RPG.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ArmorController : ControllerBase
    {
        private readonly IArmorService _armorService;
        public ArmorController(IArmorService armorService)
        {
            _armorService = armorService;
        }

        [HttpGet("{charId:int}")]
        public async Task<ActionResult<ApiResponse<List<GetArmorDto>>>> GetAllArmors(int charId){
            return Ok(await _armorService.GetAllArmor(charId));
        }

        [HttpGet("{charId:int}/{armorId:int}")]
        public async Task<ActionResult<ApiResponse<GetArmorDto>>> GetArmorById(int charId, int armorId){
            return Ok(await _armorService
                .GetArmorById(new FindArmorDto()
                {
                    CharId = charId, ArmorId = armorId
                }));
        }

        [HttpPost()]
        public async Task<ActionResult<ApiResponse<GetArmorDto>>> AddArmor(AddArmorDto request){
            return Ok(await _armorService.AddArmor(request));
        }

        [HttpPut()]
        public async Task<ActionResult<ApiResponse<GetArmorDto>>> UpdateArmor(UpdateArmorDto request){
            return Ok(await _armorService.UpdateArmor(request));
        }

        [HttpDelete("{charId:int}/{armorId:int}")]
        public async Task<ActionResult<ApiResponse<List<GetArmorDto>>>> DeleteArmor(int charId, int armorId){
            return Ok(await _armorService.DeleteArmor(new DeleteArmorDto()
            {
                CharId = charId,
                ArmorId = armorId
            }));
        }
    }
}