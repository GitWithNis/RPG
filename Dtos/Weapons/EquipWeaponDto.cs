namespace RPG.Dtos.Weapons;

public class EquipWeaponDto
{
    public int CharId { get; set; }
    public int WeaponId { get; set; }
    public bool Primary { get; set; } = true;
}