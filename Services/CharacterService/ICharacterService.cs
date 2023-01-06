using RPG.Dtos;
using RPG.Dtos.Characters;

namespace RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        public Task<ApiResponse<List<GetCharacterDto>>> GetAllCharacters();
        public Task<ApiResponse<GetCharacterDto>> GetCharacterById(int Id);
        public Task<ApiResponse<GetCharacterDto>> AddCharacter(AddCharacterDto request);
        public Task<ApiResponse<List<GetCharacterDto>>> DeleteCharacter(int Id);
        public Task<ApiResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateChar);
    }
}