using RPG.Dtos.Attacks;
using RPG.Models.Enums;

namespace RPG.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Nameless";
        public int MaxHp { get; set; } = 100;
        public int Hp { get; set; } = 100;
        public int Attack { get; set; } = 10;
        public int Pierce { get; set; } = 1;
        public int Strength { get; set; } = 10;
        
        public int Defense { get; set; } = 10;
        public decimal MeleeProt { get; set; }
        public decimal RangedProt { get; set; }
        public decimal MagicProt { get; set; }
        public int Intelligence { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public CharacterClass Class { get; set; } = CharacterClass.Warrior;

        public User? User { get; set; }
        public int UserId { get; set; }
        
        public Armor? Head { get; set; }
        public int? HeadId { get; set; }
        
        public Armor? Neck { get; set; }
        public int? NeckId { get; set; }
        
        public Armor? Chest { get; set; }
        public int? ChestId { get; set; }
        
        public Armor? Hands { get; set; }
        public int? HandsId { get; set; }
        
        public Armor? Legs { get; set; }
        public int? LegsId { get; set; }
        
        public Armor? Feet { get; set; }
        public int? FeetId { get; set; }
        
        public Armor? FingerL { get; set; }
        public int? FingerLId { get; set; }
        
        public Armor? FingerR { get; set; }
        public int? FingerRId { get; set; }
        

        public Monster? Monster { get; set; }
        public int? MonsterId { get; set; }

        public Attack GetAttack()
        {
            var rand = new Random();
            var attack = new Attack()
            {
                Pierce = Pierce,
                Damage = Attack
            };
            
            switch (Class)
            {
                case CharacterClass.Warrior:
                    attack.AttackType = AttackType.Melee;
                    attack.Damage += rand.Next(Strength + 3);
                    break;
                case CharacterClass.Knight:
                    attack.AttackType = AttackType.Melee;
                    attack.Damage += rand.Next(Strength);
                    break;
                case CharacterClass.Rogue:
                    attack.AttackType = AttackType.Melee;
                    attack.Pierce += rand.Next(Dexterity) / 3m;
                    attack.Damage += rand.Next(Dexterity + 3);
                    break;
                case CharacterClass.Archer:
                    attack.AttackType = AttackType.Ranged;
                    attack.Pierce += rand.Next(Dexterity) / 2m;
                    attack.Damage += rand.Next(Dexterity);
                    break;
                case CharacterClass.Cleric:
                    attack.Damage += rand.Next((int) ((Strength + Intelligence) / 1.5));
                    break;
                case CharacterClass.Wizard:
                    attack.AttackType = AttackType.Magic;
                    attack.Damage += rand.Next(Intelligence + 5);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return attack;
        }
        
        public void SetArmor(ArmorSlotOnChar slot, Armor armor)
        {
            Defense += armor.Defense;
            MeleeProt += armor.MeleeProt;
            RangedProt += armor.RangeProt;
            MagicProt += armor.MagicProt;

            Armor? removedArmor;
            
            switch (slot)
            {
                case ArmorSlotOnChar.Head:
                    removedArmor = Head;
                    Head = armor;
                    HeadId = armor.Id;
                    break;
                case ArmorSlotOnChar.Neck:
                    removedArmor = Neck;
                    Neck = armor;
                    NeckId = armor.Id;
                    break;
                case ArmorSlotOnChar.Chest:
                    removedArmor = Chest;
                    Chest = armor;
                    ChestId = armor.Id;
                    break;
                case ArmorSlotOnChar.Hands:
                    removedArmor = Hands;
                    Hands = armor;
                    HandsId = armor.Id;
                    break;
                case ArmorSlotOnChar.Legs:
                    removedArmor = Legs;
                    Legs = armor;
                    LegsId = armor.Id;
                    break;
                case ArmorSlotOnChar.Feet:
                    removedArmor = Feet;
                    Feet = armor;
                    FeetId = armor.Id;
                    break;
                case ArmorSlotOnChar.FingerL:
                    removedArmor = FingerL;
                    FingerL = armor;
                    FingerLId = armor.Id;
                    break;
                case ArmorSlotOnChar.FingerR:
                    removedArmor = FingerR;
                    FingerR = armor;
                    FingerRId = armor.Id;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(slot), slot, null);
            }

            if (removedArmor is null) return; 
            
            Defense -= removedArmor.Defense;
            MeleeProt -= removedArmor.MeleeProt;
            RangedProt -= removedArmor.RangeProt;
            MagicProt -= removedArmor.MagicProt;
        }
        public void RemoveArmor(ArmorSlotOnChar slot)
        {
            Armor? removedArmor;
            switch (slot)
            {
                case ArmorSlotOnChar.Head:
                    removedArmor = Head;
                    Head = null;
                    HeadId = null;
                    break;
                case ArmorSlotOnChar.Neck: 
                    removedArmor = Neck;
                    Neck = null;
                    NeckId = null;
                    break;
                case ArmorSlotOnChar.Chest:
                    removedArmor = Chest;
                    Chest = null;
                    ChestId = null;
                    break;
                case ArmorSlotOnChar.Hands:
                    removedArmor = Hands;
                    Hands = null;
                    HandsId = null;
                    break;
                case ArmorSlotOnChar.Legs:
                    removedArmor = Legs;
                    Legs = null;
                    LegsId = null;
                    break;
                case ArmorSlotOnChar.Feet:
                    removedArmor = Feet;
                    Feet = null;
                    FeetId = null;
                    break;
                case ArmorSlotOnChar.FingerL:
                    removedArmor = FingerL;
                    FingerL = null;
                    FingerLId = null;
                    break;
                case ArmorSlotOnChar.FingerR:
                    removedArmor = FingerR;
                    FingerR = null;
                    FingerRId = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(slot), slot, null);
            }

            if (removedArmor is null) return; 
            
            Defense -= removedArmor.Defense;
            MeleeProt -= removedArmor.MeleeProt;
            RangedProt -= removedArmor.RangeProt;
            MagicProt -= removedArmor.MagicProt;
        }
    }
}