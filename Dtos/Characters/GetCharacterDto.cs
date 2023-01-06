using RPG.Models;

namespace RPG.Dtos.Characters
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public CharacterClass Class { get; set; }
    }

    
}