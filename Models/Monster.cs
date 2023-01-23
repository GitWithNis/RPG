using RPG.Models.Enums;

namespace RPG.Models;

public class Monster
{
    public int Id { get; set; }
    public int Hp { get; set; } = 10;

    public int Strength { get; set; } = 5;
    public int Defense { get; set; } = 5;
    public int Intelligence { get; set; } = 5;
    public int Dexterity { get; set; } = 5;

    public int Attack { get; set; } = 5;
    public decimal Pierce { get; set; }
    public AttackType AttackType { get; set; }

    public int CharacterId {get;set;}
    public Character? Character { get; set; }

    public int CreateAttack()
    {
        var rand = new Random();

        return AttackType switch
        {
            AttackType.Melee => Attack + rand.Next(Strength + 1),
            AttackType.Ranged => Attack + rand.Next(Dexterity + 1),
            AttackType.Magic => Attack + rand.Next(Intelligence + 1),
            _ => (Strength + Dexterity + Intelligence) / 2 + Attack
        };
    }
}