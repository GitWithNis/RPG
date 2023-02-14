using RPG.Dtos;
using RPG.Dtos.Attacks;
using RPG.Dtos.Characters;
using RPG.Dtos.Weapons;

namespace RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        public Task<ApiResponse<List<GetCharacterDto>>> GetAllCharacters();
        public Task<ApiResponse<GetCharacterWithDetailDto>> GetCharacterById(int id);
        public Task<ApiResponse<GetCharacterDto>> AddCharacter(AddCharacterDto request);
        public Task<ApiResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
        public Task<ApiResponse<GetCharacterWithDetailDto>> UpdateCharacter(UpdateCharacterDto updateChar);

        public Task<ApiResponse<AttackResultDto>> AttackMonster(int charId);

        //WEAPONS --------------
        public Task<ApiResponse<GetCharacterWithDetailDto>> EquipWeapon(EquipWeaponDto request);
        public Task<ApiResponse<GetCharacterWithDetailDto>> RemoveWeapon(RemoveWeaponDto request);

        //ARMOR ----------------
        public Task<ApiResponse<GetCharacterWithDetailDto>> EquipArmor(EquipArmorDto request);
        public Task<ApiResponse<GetCharacterWithDetailDto>> RemoveArmor(RemoveArmorDto request);
    }
}