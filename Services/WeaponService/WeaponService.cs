using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Weapons;
using RPG.Models;
using RPG.Services.AuthenticationService;

namespace RPG.Services.WeaponService;

public class WeaponService : IWeaponService
{
    private readonly DataContext _dataContext;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public WeaponService(DataContext dataContext, IAuthenticationService authenticationService, IMapper mapper)
    {
        _dataContext = dataContext;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<GetWeaponDto>>> GetAllWeapons(int charId)
    {
        var weapons = await _dataContext.Weapons
            .Where(w => w.CharacterId == charId)
            .Where(w => w.Character!.UserId == _authenticationService.GetUserId())
            .Select(w => _mapper.Map<GetWeaponDto>(w))
            .ToListAsync();

        return new ApiResponse<List<GetWeaponDto>>()
        {
            Data = weapons
        };
    }

    public async Task<ApiResponse<GetWeaponDto>> GetWeaponById(FindWeaponDto request)
    {
        var weapon = await _dataContext.Weapons
            .Where(w => w.Id == request.WeaponId)
            .Where(w => w.CharacterId == request.CharId)
            .FirstOrDefaultAsync(w => w.Character!.UserId == _authenticationService.GetUserId());
        if (weapon is null)
            return new ApiResponse<GetWeaponDto>()
            {
                Success = false,
                Message = $"Weapon with id {request.CharId} not found."
            };

        return new ApiResponse<GetWeaponDto>()
        {
            Data = _mapper.Map<GetWeaponDto>(weapon)
        };
    }

    public async Task<ApiResponse<GetWeaponDto>> CreateWeapon(CreateWeaponDto request)
    {
        var weapon = _mapper.Map<Weapon>(request);
        var character = await _dataContext.Characters
            .Where(c => c.Id == request.CharId)
            .FirstOrDefaultAsync(c => c.UserId == _authenticationService.GetUserId());
        if (character is null)
            return new ApiResponse<GetWeaponDto>()
            {
                Success = false,
                Message = $"Character with id {request.CharId} not found."
            };

        weapon.Character = character;
        weapon.CharacterId = character.Id;

        await _dataContext.Weapons.AddAsync(weapon);
        await _dataContext.SaveChangesAsync();
        
        return new ApiResponse<GetWeaponDto>()
        {
            Data = _mapper.Map<GetWeaponDto>(weapon)
        };
    }

    public async Task<ApiResponse<GetWeaponDto>> UpdateWeapon(UpdateWeaponDto request)
    {
        var weapon = await _dataContext.Weapons
            .Where(w => w.Id == request.WeaponId)
            .Where(w => w.CharacterId == request.CharId)
            .FirstOrDefaultAsync(w => w.Character!.UserId == _authenticationService.GetUserId());
        if (weapon is null)
            return new ApiResponse<GetWeaponDto>()
            {
                Success = false,
                Message = $"Weapon with id {request.CharId} not found."
            };

        weapon.Name = request.WeaponName;
        await _dataContext.SaveChangesAsync();

        return new ApiResponse<GetWeaponDto>()
        {
            Data = _mapper.Map<GetWeaponDto>(weapon)
        };
    }

    public async Task<ApiResponse<List<GetWeaponDto>>> DeleteWeapon(FindWeaponDto request)
    {
        var weapon = await _dataContext.Weapons
            .Where(w => w.Id == request.WeaponId)
            .Where(w => w.CharacterId == request.CharId)
            .FirstOrDefaultAsync(w => w.Character!.UserId == _authenticationService.GetUserId());
        if (weapon is null)
            return new ApiResponse<List<GetWeaponDto>>()
            {
                Success = false,
                Message = $"Weapon with id {request.CharId} not found."
            };

        var character = await _dataContext.Characters
            .Where(c => c.Id == request.CharId)
            .FirstOrDefaultAsync(c => c.UserId == _authenticationService.GetUserId());
        if (character is null)
            return new ApiResponse<List<GetWeaponDto>>()
            {
                Success = false,
                Message = $"Character with id {request.CharId} not found."
            };

        _dataContext.Weapons.Remove(weapon);
        await _dataContext.SaveChangesAsync();

        return await GetAllWeapons(request.CharId);
    }
}