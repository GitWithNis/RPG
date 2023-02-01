using RPG.Dtos;
using RPG.Dtos.Attacks;
using RPG.Dtos.Characters;

namespace RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        public Task<ApiResponse<List<GetCharacterDto>>> GetAllCharacters();
        public Task<ApiResponse<GetCharacterDto>> GetCharacterById(int id);
        public Task<ApiResponse<GetCharacterDto>> AddCharacter(AddCharacterDto request);
        public Task<ApiResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
        public Task<ApiResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateChar);
        
        public Task<ApiResponse<GetCharacterDto>> EquipArmor(EquipArmorDto request);
        public Task<ApiResponse<GetCharacterDto>> RemoveArmor(RemoveArmorDto request);
        public Task<ApiResponse<AttackResultDto>> AttackMonster(int charId);
    }
}