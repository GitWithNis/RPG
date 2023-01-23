using RPG.Models.Enums;

namespace RPG.Dtos.Monsters;

public class CreateMonsterDto
{
    public MonsterDifficulty Difficulty { get; set; }
    public int CharId { get; set; }
}