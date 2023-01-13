using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Armors;
using RPG.Models;
using RPG.Services.CharacterService;

namespace RPG.Services.ArmorService
{
    public class ArmorService : IArmorService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ICharacterService _characterService;
        public ArmorService(DataContext dataContext, ICharacterService characterService, IMapper mapper)
        {
            _mapper = mapper;
            _characterService = characterService;
            _dataContext = dataContext;
        }

        public async Task<ApiResponse<GetArmorDto>> AddArmor(AddArmorDto request)
        {
            var character = await _dataContext.Characters
                .FirstOrDefaultAsync(c => c.Id == request.CharacterId);
            if (character is null)
                return new ApiResponse<GetArmorDto>(){
                    Success = false,
                    Message = $"Character with Id {request.CharacterId} not found."
                };

            var armor = _mapper.Map<Armor>(request);
            armor.CharacterId = character.Id;

            await _dataContext.AddAsync(armor);
            await _dataContext.SaveChangesAsync();

            return new ApiResponse<GetArmorDto>(){
                Data = _mapper.Map<GetArmorDto>(armor)
            };
        }

        public async Task<ApiResponse<List<GetArmorDto>>> DeleteArmor(int id)
        {
            var armor = await _dataContext.Armor
                .FirstOrDefaultAsync(a => a.Id == id);
            if (armor is null)
                return new ApiResponse<List<GetArmorDto>>(){
                    Success = false,
                    Message = $"Could not find Armor with Id {id}."
                };

            _dataContext.Remove(armor);
            await _dataContext.SaveChangesAsync();

            return await GetAllArmor();
        }

        public async Task<ApiResponse<List<GetArmorDto>>> GetAllArmor()
        {
            return new ApiResponse<List<GetArmorDto>>(){
                Data = await _dataContext.Armor
                    .Select(a => _mapper.Map<GetArmorDto>(a))
                    .ToListAsync()
            };
        }

        public async Task<ApiResponse<GetArmorDto>> GetArmorById(int id)
        {
            var armor = await _dataContext.Armor
                .FirstOrDefaultAsync(a => a.Id == id);
            if (armor is null)
                return new ApiResponse<GetArmorDto>(){
                    Success = false,
                    Message = $"Could not find Armor with Id {id}."
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