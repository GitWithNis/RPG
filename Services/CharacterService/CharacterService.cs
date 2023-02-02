using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Attacks;
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

        public async Task<ApiResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var character = await _dataContext.Characters
                .Where(c => c.User!.Id == _authenticationService.GetUserId())
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (character is null)
                return new ApiResponse<List<GetCharacterDto>>(){
                    Success = false,
                    Message = $"Character with Id {id} not found."
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

        public async Task<ApiResponse<GetCharacterWithArmorDto>> GetCharacterById(int id)
        {
            var character = await _dataContext.Characters
                .Where(c => c.User!.Id == _authenticationService.GetUserId())
                .Include(e => e.Head)
                .Include(e => e.Neck)
                .Include(e => e.Chest)
                .Include(e => e.Hands)
                .Include(e => e.Legs)
                .Include(e => e.Feet)
                .Include(e => e.FingerL)
                .Include(e => e.FingerR)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (character is null)
                return new ApiResponse<GetCharacterWithArmorDto>(){
                    Success = false,
                    Message = $"Character with Id {id} not found."
                };

            return new ApiResponse<GetCharacterWithArmorDto>(){
                Data = _mapper.Map<GetCharacterWithArmorDto>(character)
            };
        }

        public async Task<ApiResponse<GetCharacterWithArmorDto>> UpdateCharacter(UpdateCharacterDto updateChar)
        {
            var character = await _dataContext.Characters
                .Where(c => c.User!.Id == _authenticationService.GetUserId())
                .FirstOrDefaultAsync(e => e.Id == updateChar.Id);

            if (character is null)
                return new ApiResponse<GetCharacterWithArmorDto>(){
                    Success = false,
                    Message = $"Character with Id {updateChar.Id} not found."
                };

            _mapper.Map(updateChar, character);
            await _dataContext.SaveChangesAsync();

            return await GetCharacterById(updateChar.Id);           
        }

        // --------------------- ARMOR RELATED SERVICES:
        public async Task<ApiResponse<GetCharacterWithArmorDto>> RemoveArmor(RemoveArmorDto request)
        {
            var character = await _dataContext.Characters
                .Where(c => c.User!.Id == _authenticationService.GetUserId())
                .Include(e => e.Head)
                .Include(e => e.Neck)
                .Include(e => e.Chest)
                .Include(e => e.Hands)
                .Include(e => e.Legs)
                .Include(e => e.Feet)
                .Include(e => e.FingerL)
                .Include(e => e.FingerR)
                .FirstOrDefaultAsync(c => c.Id == request.CharId);
            if (character is null)
                return new ApiResponse<GetCharacterWithArmorDto>()
                {
                    Success = false,
                    Message = $"Character with Id {request.CharId} not found."
                };

            character.RemoveArmor(request.Slot);

            await _dataContext.SaveChangesAsync();

            return new ApiResponse<GetCharacterWithArmorDto>(){
                Data = _mapper.Map<GetCharacterWithArmorDto>(character)
            };
        }

        public async Task<ApiResponse<GetCharacterWithArmorDto>> EquipArmor(EquipArmorDto request)
        {
            if (request.FingerIfRing is < 0 or > 1)
                return new ApiResponse<GetCharacterWithArmorDto>()
                {
                    Success = false,
                    Message = "Invalid FingerIfRing value. If equipping a ring, set FingerIfRing to 0 for Left hand, and 1 for Right."
                };

            var character = await _dataContext.Characters
                .Where(c => c.User!.Id == _authenticationService.GetUserId())
                .Include(e => e.Head)
                .Include(e => e.Neck)
                .Include(e => e.Chest)
                .Include(e => e.Hands)
                .Include(e => e.Legs)
                .Include(e => e.Feet)
                .Include(e => e.FingerL)
                .Include(e => e.FingerR)
                .FirstOrDefaultAsync(c => c.Id == request.CharId);
            if (character is null)
                return new ApiResponse<GetCharacterWithArmorDto>()
                {
                    Success = false,
                    Message = $"Character with Id {request.CharId} not found."
                };

            var armor = await _dataContext.Armor
                .Where(a => a.CharacterId == request.CharId)
                .FirstOrDefaultAsync(a => a.Id == request.ArmorId);
            if (armor is null)
                return new ApiResponse<GetCharacterWithArmorDto>()
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
            
            character.SetArmor(slotToEquip, armor);

            await _dataContext.SaveChangesAsync();
            
            return new ApiResponse<GetCharacterWithArmorDto>(){
                Data = _mapper.Map<GetCharacterWithArmorDto>(character)
            };
        }
        
        // --------------------- MONSTER RELATED SERVICES:

        public async Task<ApiResponse<AttackResultDto>> AttackMonster(int charId)
        {
            var character = await _dataContext.Characters
                .Where(c => c.UserId == _authenticationService.GetUserId())
                .Include(c => c.Monster)
                .FirstOrDefaultAsync(c => c.Id == charId);
            if (character is null)
                return new ApiResponse<AttackResultDto>()
                {
                    Success = false,
                    Message = $"Character with id {charId} not found."
                };

            if (character.Monster is null)
                return new ApiResponse<AttackResultDto>()
                {
                    Success = false,
                    Message = $"No monster is associated with character."
                };

            var attack = character.GetAttack();

            var cType = attack.AttackType;
            var mType = character.Monster.AttackType;
            var weak = (cType == AttackType.Magic && mType == AttackType.Ranged) ||
                           (cType == AttackType.Ranged && mType == AttackType.Melee) ||
                           (cType == AttackType.Melee && mType == AttackType.Magic);
            if (weak) attack.Damage = (int)(attack.Damage * 1.5);
            
            //applying damage to monster and have monster attack character
            var ret = new ApiResponse<AttackResultDto>()
            {
                Data = new AttackResultDto
                {
                    MonsterHP = character.Monster.Hp,
                    CharacterDealt = character.Monster.GetAttacked(attack),
                    MonsterDealt = character.Monster.Hp <= 0 ? 
                                        0 :
                                        character.Monster.AttackChar(),
                    CharacterHP = character.Hp
                }
            };

            if (character.Monster.Hp <= 0)
            {
                //monster defeated
                _dataContext.Monsters.Remove(character.Monster);
                ret.Message = "Monster defeated!";
            }
            
            await _dataContext.SaveChangesAsync();
            return ret;
        }
    }
}