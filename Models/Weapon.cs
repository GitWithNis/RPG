using RPG.Models.Enums;

namespace RPG.Models;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; } = "Nameless Weapon";
    public AttackType AttackType { get; set; }

    public int Damage { get; set; }
    public decimal Pierce { get; set; }

    public Character? Character { get; set; }
    public int CharacterId { get; set; }

    public WeaponSlot EquippedWeaponSlot { get; set; }
}