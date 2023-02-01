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
        public User? User { get; set; }
        public int UserId { get; set; }
        
        public CharacterClass Class { get; set; } = CharacterClass.Warrior;
        public CharArmor CharArmor { get; set; } = new();

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
    }

    public class CharArmor 
    {
        public int Id { get; set; }
        
        public int CharacterId { get; set; }
        public Character? Character { get; set; }
        
        public Armor? Head { get; set; }
        public Armor? Neck { get; set; }
        public Armor? Chest { get; set; }
        public Armor? Hands { get; set; }
        public Armor? Legs { get; set; }
        public Armor? Feet { get; set; }
        public Armor? FingerL { get; set; }
        public Armor? FingerR { get; set; }

        public void SetArmor(ArmorSlotOnChar slot, Armor armor)
        {
            if (Character is null) return;
            
            Character.Defense += armor.Defense;
            Character.MeleeProt += armor.MeleeProt;
            Character.RangedProt += armor.RangeProt;
            Character.MagicProt += armor.MagicProt;

            Armor? removedArmor;
            
            switch (slot)
            {
                case ArmorSlotOnChar.Head:
                    removedArmor = Head;
                    Head = armor;
                    break;
                case ArmorSlotOnChar.Neck:
                    removedArmor = Neck;
                    Neck = armor;
                    break;
                case ArmorSlotOnChar.Chest:
                    removedArmor = Chest;
                    Chest = armor;
                    break;
                case ArmorSlotOnChar.Hands:
                    removedArmor = Hands;
                    Hands = armor;
                    break;
                case ArmorSlotOnChar.Legs:
                    removedArmor = Legs;
                    Legs = armor;
                    break;
                case ArmorSlotOnChar.Feet:
                    removedArmor = Feet;
                    Feet = armor;
                    break;
                case ArmorSlotOnChar.FingerL:
                    removedArmor = FingerL;
                    FingerL = armor;
                    break;
                case ArmorSlotOnChar.FingerR:
                    removedArmor = FingerR;
                    FingerR = armor;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(slot), slot, null);
            }

            if (removedArmor is null) return; 
            
            Character.Defense -= removedArmor.Defense;
            Character.MeleeProt -= removedArmor.MeleeProt;
            Character.RangedProt -= removedArmor.RangeProt;
            Character.MagicProt -= removedArmor.MagicProt;
            
        }
        
        public void RemoveArmor(ArmorSlotOnChar slot)
        {
            Armor? removedArmor;
            switch (slot)
            {
                case ArmorSlotOnChar.Head:
                    removedArmor = Head;
                    Head = null;
                    break;
                case ArmorSlotOnChar.Neck: 
                    removedArmor = Neck;
                    Neck = null;
                    break;
                case ArmorSlotOnChar.Chest:
                    removedArmor = Chest;
                    Chest = null;
                    break;
                case ArmorSlotOnChar.Hands:
                    removedArmor = Hands;
                    Hands = null;
                    break;
                case ArmorSlotOnChar.Legs:
                    removedArmor = Legs;
                    Legs = null;
                    break;
                case ArmorSlotOnChar.Feet:
                    removedArmor = Feet;
                    Feet = null;
                    break;
                case ArmorSlotOnChar.FingerL:
                    removedArmor = FingerL;
                    FingerL = null;
                    break;
                case ArmorSlotOnChar.FingerR:
                    removedArmor = FingerR;
                    FingerR = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(slot), slot, null);
            }

            if (removedArmor is null) return; 
            
            Character!.Defense -= removedArmor.Defense;
            Character!.MeleeProt -= removedArmor.MeleeProt;
            Character!.RangedProt -= removedArmor.RangeProt;
            Character!.MagicProt -= removedArmor.MagicProt;
        }
    }
}