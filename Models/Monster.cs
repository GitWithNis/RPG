using RPG.Dtos.Attacks;
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

    public int GetAttacked(Attack attack)
    {
        var rand = new Random();
        var damage = (int) (attack.Damage - rand.Next(Defense / 3, Defense) - attack.Pierce);
        
        if (damage <= 0) return 0;

        Hp -= damage;
        return damage;
    }

    public int AttackChar()
    {
        var rand = new Random();
        var attack = new Attack()
        {
            Pierce = Pierce,
            Damage = Attack,
            AttackType = AttackType
        };

        switch (AttackType)
        {
            case AttackType.Melee:
                attack.Damage += rand.Next(Strength + 3);
                attack.Pierce += rand.Next(Dexterity) / 2m;
                attack.Pierce -= Character!.MeleeProt;
                break;
            case AttackType.Ranged:
                attack.Damage += rand.Next(Dexterity);
                attack.Pierce += rand.Next(Dexterity) / 2m;
                attack.Pierce -= Character!.RangedProt;
                break;
            case AttackType.Magic:
                attack.Damage += rand.Next(Intelligence + 5);
                attack.Pierce -= Character!.MagicProt;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        var cType = Character.GetAttack().AttackType;
        var weak = (cType == AttackType.Magic && AttackType == AttackType.Ranged) ||
                   (cType == AttackType.Ranged && AttackType == AttackType.Melee) ||
                   (cType == AttackType.Melee && AttackType == AttackType.Magic);
        if (weak) attack.Damage = (int)(attack.Damage * 1.5);

        var defAfterPierce = (int) (Character.Defense - attack.Pierce);
        var damage = Math.Max(0, attack.Damage - defAfterPierce);
        Character.Hp -= damage;
        return damage;
    }
}