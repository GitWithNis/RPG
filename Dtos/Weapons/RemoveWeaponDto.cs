namespace RPG.Dtos.Weapons;

public class RemoveWeaponDto
{
    public int CharId { get; set; }
    public bool Primary { get; set; } = true;
}