using System.ComponentModel;
using RPG.Models.Enums;

namespace RPG.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Nameless";
        public int MaxHP { get; set; } = 100;
        public int HP { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public CharacterClass Class { get; set; } = CharacterClass.Warrior;

        // Head, Neck, Chest, Hands, Fingers x 2, Legs, Feet in that order
        List<Armor> ArmorList { get; set; } = new List<Armor>(8);
        
    }
}