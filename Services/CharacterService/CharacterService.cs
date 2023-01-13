using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Armors;
using RPG.Dtos.Characters;
using RPG.Models;
using RPG.Models.Enums;

namespace RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        
        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ApiResponse<GetCharacterDto>> AddCharacter(AddCharacterDto request)
        {
            var response = new ApiResponse<GetCharacterDto>();
            var character = _mapper.Map<Character>(request);

            await _dataContext.Characters.AddAsync(character);
            await _dataContext.SaveChangesAsync();

            response.Data = _mapper.Map<GetCharacterDto>(character);
            return response;
        }

        public async Task<ApiResponse<List<GetCharacterDto>>> DeleteCharacter(int Id)
        {
            var character = await _dataContext.Characters
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
            return new ApiResponse<List<GetCharacterDto>>(){
                Data = await _dataContext.Characters.Select(e => _mapper.Map<GetCharacterDto>(e)).ToListAsync()
            };
        }

        public async Task<ApiResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            var character = await _dataContext.Characters
                .Include(e => e.CharArmor)
                .Include(e => e.CharArmor.Head)
                .Include(e => e.CharArmor.Neck)
                .Include(e => e.CharArmor.Chest)
                .Include(e => e.CharArmor.Hands)
                .Include(e => e.CharArmor.Legs)
                .Include(e => e.CharArmor.Feet)
                .Include(e => e.CharArmor.FingerL)
                .Include(e => e.CharArmor.FingerR)
                .FirstOrDefaultAsync(e => e.Id == Id);

            if (character is null)
                return new ApiResponse<GetCharacterDto>(){
                    Success = false,
                    Message = $"Character with Id {Id} not found."
                };

            return new ApiResponse<GetCharacterDto>(){
                Data = _mapper.Map<GetCharacterDto>(character)
            };
        }

        public async Task<ApiResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateChar)
        {
            var character = await _dataContext.Characters
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

            //character.CharArmor.SetArmor(slotToEquip, armor);

            switch (slotToEquip)
            {
                case ArmorSlotOnChar.Head: 
                    character.CharArmor.Head = armor;
                    break;
                case ArmorSlotOnChar.Neck: 
                    character.CharArmor.Neck = armor;
                    break;
                case ArmorSlotOnChar.Chest: 
                    character.CharArmor.Chest = armor;
                    break;
                case ArmorSlotOnChar.Hands: 
                    character.CharArmor.Hands = armor;
                    break;
                case ArmorSlotOnChar.Legs: 
                    character.CharArmor.Legs = armor;
                    break;
                case ArmorSlotOnChar.Feet: 
                    character.CharArmor.Feet = armor;
                    break;
                case ArmorSlotOnChar.FingerL: 
                    character.CharArmor.FingerL = armor;
                    break;
                case ArmorSlotOnChar.FingerR: 
                    character.CharArmor.FingerR = armor;
                    break;
            }

            await _dataContext.SaveChangesAsync();
            
            return new ApiResponse<GetCharacterDto>(){
                Data = _mapper.Map<GetCharacterDto>(character)
            };
        }
    }
}