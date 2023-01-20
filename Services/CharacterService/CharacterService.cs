using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Characters;
using RPG.Models;
using RPG.Models.Enums;
using RPG.Services.AuthenticationService;

namespace RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly IAuthenticationService _authenticationService;

        public CharacterService(IMapper mapper, DataContext dataContext, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _dataContext = dataContext;
            _authenticationService = authenticationService;
        }

        public async Task<ApiResponse<GetCharacterDto>> AddCharacter(AddCharacterDto request)
        {
            var response = new ApiResponse<GetCharacterDto>();
            var character = _mapper.Map<Character>(request);
            
            var user = await _dataContext.Users
                .FirstOrDefaultAsync(u => u.Id == _authenticationService.GetUserId());
            if (user is null)
                return new ApiResponse<GetCharacterDto>()
                {
                    Success = false,
                    Message = "Error with Authentication."
                };
            
            character.User = user;

            await _dataContext.Characters.AddAsync(character);
            await _dataContext.SaveChangesAsync();

            response.Data = _mapper.Map<GetCharacterDto>(character);
            return response;
        }

        public async Task<ApiResponse<List<GetCharacterDto>>> DeleteCharacter(int Id)
        {
            var character = await _dataContext.Characters
                .Where(c => c.User.Id == _authenticationService.GetUserId())
                .FirstOrDefaultAsync(c => c.Id == Id);
            
            if (character is null)
                return new ApiResponse<List<GetCharacterDto>>(){
                    Success = false,
                    Message = $"Character with Id {Id} not found."
                };
                        
            _dataContext.Characters.Remove(character);
            await _dataContext.SaveChangesAsync();

            return await GetAllCharacters();
        }

        public async Task<ApiResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var characters = await _dataContext.Characters
                .Where(c => c.User!.Id == _authenticationService.GetUserId())
                .Select(c => _mapper.Map<GetCharacterDto>(c))
                .ToListAsync();
            
            return new ApiResponse<List<GetCharacterDto>>(){
                Data = characters
            };
        }

        public async Task<ApiResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var character = await _dataContext.Characters
                .Where(c => c.User.Id == _authenticationService.GetUserId())
                .Include(e => e.CharArmor)
                .Include(e => e.CharArmor.Head)
                .Include(e => e.CharArmor.Neck)
                .Include(e => e.CharArmor.Chest)
                .Include(e => e.CharArmor.Hands)
                .Include(e => e.CharArmor.Legs)
                .Include(e => e.CharArmor.Feet)
                .Include(e => e.CharArmor.FingerL)
                .Include(e => e.CharArmor.FingerR)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (character is null)
                return new ApiResponse<GetCharacterDto>(){
                    Success = false,
                    Message = $"Character with Id {id} not found."
                };

            return new ApiResponse<GetCharacterDto>(){
                Data = _mapper.Map<GetCharacterDto>(character)
            };
        }

        public async Task<ApiResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateChar)
        {
            var character = await _dataContext.Characters
                .Where(c => c.User!.Id == _authenticationService.GetUserId())
                .FirstOrDefaultAsync(e => e.Id == updateChar.Id);

            if (character is null)
                return new ApiResponse<GetCharacterDto>(){
                    Success = false,
                    Message = $"Character with Id {updateChar.Id} not found."
                };

            _mapper.Map(updateChar, character);
            await _dataContext.SaveChangesAsync();

            return await GetCharacterById(updateChar.Id);           
        }

        // --------------------- ARMOR SERVICES:
        public async Task<ApiResponse<GetCharacterDto>> RemoveArmor(RemoveArmorDto request)
        {
            var character = await _dataContext.Characters
                .Where(c => c.User.Id == _authenticationService.GetUserId())
                .Include(e => e.CharArmor)
                .Include(e => e.CharArmor.Head)
                .Include(e => e.CharArmor.Neck)
                .Include(e => e.CharArmor.Chest)
                .Include(e => e.CharArmor.Hands)
                .Include(e => e.CharArmor.Legs)
                .Include(e => e.CharArmor.Feet)
                .Include(e => e.CharArmor.FingerL)
                .Include(e => e.CharArmor.FingerR)
                .FirstOrDefaultAsync(c => c.Id == request.CharId);
            if (character is null)
                return new ApiResponse<GetCharacterDto>()
                {
                    Success = false,
                    Message = $"Character with Id {request.CharId} not found."
                };

            character.CharArmor.RemoveArmor(request.Slot);

            await _dataContext.SaveChangesAsync();

            return new ApiResponse<GetCharacterDto>(){
                Data = _mapper.Map<GetCharacterDto>(character)
            };
        }

        public async Task<ApiResponse<GetCharacterDto>> EquipArmor(EquipArmorDto request)
        {
            if (request.FingerIfRing < 0 || request.FingerIfRing > 1)
                return new ApiResponse<GetCharacterDto>()
                {
                    Success = false,
                    Message = "Invalid FingerIfRing value. If equipping a ring, set FingerIfRing to 0 for Left hand, and 1 for Right."
                };

            var character = await _dataContext.Characters
                .Where(c => c.User.Id == _authenticationService.GetUserId())
                .Include(e => e.CharArmor)
                .Include(e => e.CharArmor.Head)
                .Include(e => e.CharArmor.Neck)
                .Include(e => e.CharArmor.Chest)
                .Include(e => e.CharArmor.Hands)
                .Include(e => e.CharArmor.Legs)
                .Include(e => e.CharArmor.Feet)
                .Include(e => e.CharArmor.FingerL)
                .Include(e => e.CharArmor.FingerR)
                .FirstOrDefaultAsync(c => c.Id == request.CharId);
            if (character is null)
                return new ApiResponse<GetCharacterDto>()
                {
                    Success = false,
                    Message = $"Character with Id {request.CharId} not found."
                };

            var armor = await _dataContext.Armor
                .Where(c => c.Id == _authenticationService.GetUserId())
                .Where(a => a.CharacterId == character.Id)
                .FirstOrDefaultAsync(a => a.Id == request.ArmorId);
            if (armor is null)
                return new ApiResponse<GetCharacterDto>()
                {
                    Success = false,
                    Message = $"Armor with Id {request.ArmorId} not found."
                };

            ArmorSlotOnChar slotToEquip;

            if (armor.Slot == ArmorSlot.Fingers){
                slotToEquip =
                    request.FingerIfRing == 0 ? 
                    ArmorSlotOnChar.FingerL :
                    ArmorSlotOnChar.FingerR;
            } else {
               slotToEquip = (ArmorSlotOnChar) armor.Slot;
            }
            
            character.CharArmor.SetArmor(slotToEquip, armor);

            await _dataContext.SaveChangesAsync();
            
            return new ApiResponse<GetCharacterDto>(){
                Data = _mapper.Map<GetCharacterDto>(character)
            };
        }
    }
}