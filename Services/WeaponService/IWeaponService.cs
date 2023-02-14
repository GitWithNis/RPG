using RPG.Dtos;
using RPG.Dtos.Weapons;

namespace RPG.Services.WeaponService;

public interface IWeaponService
{
    public Task<ApiResponse<List<GetWeaponDto>>> GetAllWeapons(int charId);
    public Task<ApiResponse<GetWeaponDto>> GetWeaponById(FindWeaponDto request);
    public Task<ApiResponse<GetWeaponDto>> CreateWeapon(CreateWeaponDto request);
    public Task<ApiResponse<GetWeaponDto>> UpdateWeapon(UpdateWeaponDto name);
    public Task<ApiResponse<List<GetWeaponDto>>> DeleteWeapon(FindWeaponDto request);
}