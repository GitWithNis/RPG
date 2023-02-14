using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Armors;
using RPG.Models;
using RPG.Services.AuthenticationService;

namespace RPG.Services.ArmorService
{
    public class ArmorService : IArmorService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public ArmorService(DataContext dataContext, IAuthenticationService authenticationService, IMapper mapper)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
            _dataContext = dataContext;
        }

        public async Task<ApiResponse<GetArmorDto>> AddArmor(AddArmorDto request)
        {
            var character = await _dataContext.Characters
                .Where(c => c.Id == request.CharacterId)
                .FirstOrDefaultAsync(c => c.UserId == _authenticationService.GetUserId());
            if (character is null)
                return new ApiResponse<GetArmorDto>(){
                    Success = false,
                    Message = $"Character with Id {request.CharacterId} not found."
                };

            var armor = _mapper.Map<Armor>(request);
            armor.CharacterId = character.Id;

            _dataContext.Add((object)armor);
            await _dataContext.SaveChangesAsync();

            return new ApiResponse<GetArmorDto>(){
                Data = _mapper.Map<GetArmorDto>(armor)
            };
        }

        public async Task<ApiResponse<List<GetArmorDto>>> DeleteArmor(DeleteArmorDto request)
        {
            var armor = await _dataContext.Armor
                .Where(a => a.Id == request.ArmorId)
                .Where(a => a.CharacterId == request.CharId)
                .FirstOrDefaultAsync(a => a.Character!.UserId == _authenticationService.GetUserId());
            if (armor is null)
                return new ApiResponse<List<GetArmorDto>>(){
                    Success = false,
                    Message = $"Could not find Armor with Id {request.ArmorId}."
                };
            
            _dataContext.Remove(armor);
            await _dataContext.SaveChangesAsync();

            return await GetAllArmor(request.CharId);
        }

        public async Task<ApiResponse<List<GetArmorDto>>> GetAllArmor(int charId)
        {
            return new ApiResponse<List<GetArmorDto>>(){
                Data = await _dataContext.Armor
                    .Where(a => a.CharacterId == charId)
                    .Where(a => a.Character!.UserId == _authenticationService.GetUserId())
                    .Select(a => _mapper.Map<GetArmorDto>(a))
                    .ToListAsync()
            };
        }

        public async Task<ApiResponse<GetArmorDto>> GetArmorById(FindArmorDto request)
        {
            var armor = await _dataContext.Armor
                .Where(a => a.Id == request.ArmorId)
                .Where(a => a.CharacterId == request.CharId)
                .FirstOrDefaultAsync(a => a.Character!.UserId == _authenticationService.GetUserId());
            if (armor is null)
                return new ApiResponse<GetArmorDto>(){
                    Success = false,
                    Message = $"Could not find Armor with Id {request.ArmorId}."
                };

            return new ApiResponse<GetArmorDto>(){
                Data = _mapper.Map<GetArmorDto>(armor)
            };
        }

        public async Task<ApiResponse<GetArmorDto>> UpdateArmor(UpdateArmorDto request)
        {
            var armor = await _dataContext.Armor
                .FirstOrDefaultAsync(a => a.Id == request.Id);
            if (armor is null)
                return new ApiResponse<GetArmorDto>(){
                    Success = false,
                    Message = $"Could not find Armor with Id {request.Id}."
                };

            _mapper.Map(request, armor);
            await _dataContext.SaveChangesAsync();
            
            return new ApiResponse<GetArmorDto>(){
                Data = _mapper.Map<GetArmorDto>(armor)
            };
        }
    }
}