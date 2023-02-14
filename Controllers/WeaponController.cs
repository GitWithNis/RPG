using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Dtos;
using RPG.Dtos.Weapons;
using RPG.Services.WeaponService;

namespace RPG.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class WeaponController : ControllerBase
{
    private readonly IWeaponService _weaponService;

    public WeaponController(IWeaponService weaponService)
    {
        _weaponService = weaponService;
    }
    
    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<GetWeaponDto>>>> GetAllWeapons(int charId)
    {
        return Ok(await _weaponService.GetAllWeapons(charId));
    }

    [HttpGet("{charId:int}/{weaponId:int}")]
    public async Task<ActionResult<ApiResponse<GetWeaponDto>>> GetWeaponById(int charId, int weaponId)
    {
        return Ok(await _weaponService
            .GetWeaponById(new FindWeaponDto()
            {
                WeaponId = weaponId, 
                CharId = charId
            }));
    }

    [HttpPost()]
    public async Task<ActionResult<ApiResponse<GetWeaponDto>>> CreateWeapon(CreateWeaponDto request)
    {
        return Ok(await _weaponService.CreateWeapon(request));
    }

    [HttpPut()]
    public async Task<ActionResult<ApiResponse<GetWeaponDto>>> UpdateWeapon(UpdateWeaponDto request)
    {
        return Ok(await _weaponService.UpdateWeapon(request));
    }

    [HttpDelete()]
    public async Task<ActionResult<ApiResponse<List<GetWeaponDto>>>> DeleteWeapon(FindWeaponDto request)
    {
        return Ok(await _weaponService.DeleteWeapon(request));
    }
}