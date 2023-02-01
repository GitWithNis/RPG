using RPG.Models.Enums;

namespace RPG.Dtos.Attacks;

public class Attack
{
    public int Damage { get; set; }
    public AttackType AttackType { get; set; }
    public decimal Pierce { get; set; }
}