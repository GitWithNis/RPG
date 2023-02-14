namespace RPG.Dtos.Weapons;

public class UpdateWeaponDto
{
    public int WeaponId { get; set; }
    public int CharId { get; set; }
    public string WeaponName { get; set; } = "Nameless";
}