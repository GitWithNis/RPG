using RPG.Dtos;
using RPG.Dtos.Monsters;

namespace RPG.Services.MonsterService;

public interface IMonsterService {
    public Task<ApiResponse<List<GetMonsterDto>>> GetAllMonsters(int charId);
    public Task<ApiResponse<GetMonsterDto>> GetMonsterById(int charId, int monsterId);
    public Task<ApiResponse<GetMonsterDto>> CreateMonster(CreateMonsterDto request);
}