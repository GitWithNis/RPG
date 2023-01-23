using RPG.Models.Enums;

namespace RPG.Dtos.Monsters;

public class GetMonsterDto
{
    public int Id { get; set; }
    public int Hp { get; set; } = 10;

    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }

    public int Attack { get; set; } = 1;
    public decimal Pierce { get; set; } = 0;
    public AttackType AttackType { get; set; }
}