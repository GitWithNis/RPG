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

        [HttpGet()]
        public async Task<ActionResult<ApiResponse<List<GetArmorDto>>>> GetAllArmors(){
            return Ok(await _armorService.GetAllArmor());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<GetArmorDto>>> GetArmorById(int id){
            return Ok(await _armorService.GetArmorById(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult<ApiResponse<GetArmorDto>>> AddArmor(AddArmorDto request){
            return Ok(await _armorService.AddArmor(request));
        }

        [HttpPut("update")]
        public async Task<ActionResult<ApiResponse<GetArmorDto>>> UpdateArmor(UpdateArmorDto request){
            return Ok(await _armorService.UpdateArmor(request));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<List<GetArmorDto>>>> DeleteArmor(int id){
            return Ok(await _armorService.DeleteArmor(id));
        }
    }
}