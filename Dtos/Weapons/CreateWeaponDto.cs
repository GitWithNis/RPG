using RPG.Models.Enums;

namespace RPG.Dtos.Weapons;

public class CreateWeaponDto
{
    public int CharId;
    
    public string Name { get; set; } = "Nameless Weapon";
    public AttackType AttackType { get; set; }

    public int Damage { get; set; }
    public decimal Pierce { get; set; }
}