using RPG.Models.Enums;

namespace RPG.Dtos.Characters
{
    public class GetCharacterDto
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
    }

    
}