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

        public CharArmor CharArmor { get; set; } = new CharArmor();
        
    }

    public class CharArmor 
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public Armor? Head { get; set; }
        public Armor? Neck { get; set; }
        public Armor? Chest { get; set; }
        public Armor? Hands { get; set; }
        public Armor? Legs { get; set; }
        public Armor? Feet { get; set; }
        public Armor? FingerL { get; set; }
        public Armor? FingerR { get; set; }

        public void SetArmor(ArmorSlotOnChar slot, Armor armor){
            switch (slot)
            {
                case ArmorSlotOnChar.Head: 
                    Head = armor;
                    break;
                case ArmorSlotOnChar.Neck: 
                    Neck = armor;
                    break;
                case ArmorSlotOnChar.Chest: 
                    Chest = armor;
                    break;
                case ArmorSlotOnChar.Hands: 
                    Hands = armor;
                    break;
                case ArmorSlotOnChar.Legs: 
                    Legs = armor;
                    break;
                case ArmorSlotOnChar.Feet: 
                    Feet = armor;
                    break;
                case ArmorSlotOnChar.FingerL: 
                    FingerL = armor;
                    break;
                case ArmorSlotOnChar.FingerR: 
                    FingerR = armor;
                    break;
            }
        }
        public void RemoveArmor(ArmorSlotOnChar slot){
            switch (slot)
            {
                case ArmorSlotOnChar.Head: 
                    Head = null;
                    break;
                case ArmorSlotOnChar.Neck: 
                    Neck = null;
                    break;
                case ArmorSlotOnChar.Chest: 
                    Chest = null;
                    break;
                case ArmorSlotOnChar.Hands: 
                    Hands = null;
                    break;
                case ArmorSlotOnChar.Legs: 
                    Legs = null;
                    break;
                case ArmorSlotOnChar.Feet: 
                    Feet = null;
                    break;
                case ArmorSlotOnChar.FingerL: 
                    FingerL = null;
                    break;
                case ArmorSlotOnChar.FingerR: 
                    FingerR = null;
                    break;
            }
        }
    }
}