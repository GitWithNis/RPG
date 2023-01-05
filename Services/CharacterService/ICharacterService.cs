using RPG.Dtos;

namespace RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        public Task<ApiResponse<List<GetCharacterDto>>> GetAllCharacters();
        public Task<ApiResponse<GetCharacterDto>> GetCharacterById(int Id);
    }
}