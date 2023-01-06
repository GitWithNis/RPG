using RPG.Models.Enums;

namespace RPG.Dtos.Characters
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Nameless";
        public CharacterClass Class { get; set; }
    }
}