using RPG.Models;
using RPG.Models.Enums;

namespace RPG.Dtos.Characters;

public class GetCharacterWithArmorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MaxHp { get; set; }
    public int Hp { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public decimal MeleeProt { get; set; }
    public decimal RangedProt { get; set; }
    public decimal MagicProt { get; set; }
    public CharacterClass Class { get; set; }
        
    public Armor? Head { get; set; }
    public Armor? Neck { get; set; }
    public Armor? Chest { get; set; }
    public Armor? Hands { get; set; }
    public Armor? Legs { get; set; }
    public Armor? Feet { get; set; }
    public Armor? FingerL { get; set; }
    public Armor? FingerR { get; set; } 
}