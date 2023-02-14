using RPG.Dtos.Attacks;
using RPG.Models.Enums;

namespace RPG.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Nameless";
        public User? User { get; set; }
        public int UserId { get; set; }
        public CharacterClass Class { get; set; } = CharacterClass.Warrior;
        public int MaxHp { get; set; } = 100;
        public int Hp { get; set; } = 100;
        public int Attack { get; set; } = 10;
        public int Pierce { get; set; } = 1;
        
        
        // STATS ---------------------------
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public decimal MeleeProt { get; set; }
        public decimal RangedProt { get; set; }
        public decimal MagicProt { get; set; }
        
        // ARMOR ---------------------------
        public List<Armor> Armors { get; set; } = new List<Armor>();

        public void SetArmor(ArmorSlotOnChar slot, Armor armor)
        {
            Defense += armor.Defense;
            MeleeProt += armor.MeleeProt;
            RangedProt += armor.RangeProt;
            MagicProt += armor.MagicProt;

            var removedArmor = Armors.FirstOrDefault(a => a.SlotOnChar == slot);
            if (removedArmor is not null)
            {
                Defense -= removedArmor.Defense;
                MeleeProt -= removedArmor.Defense;
                RangedProt -= removedArmor.Defense;
                MagicProt -= removedArmor.Defense;

                removedArmor.SlotOnChar = ArmorSlotOnChar.Unequipped; //not equipped anymore
            }

            armor.SlotOnChar = slot; //equip new armor
        }
        public void RemoveArmor(ArmorSlotOnChar slot)
        {
            if (slot == ArmorSlotOnChar.Unequipped) return;
            
            var removedArmor = Armors.FirstOrDefault(a => a.SlotOnChar == slot);
            if (removedArmor is null) return;
            
            Defense -= removedArmor.Defense;
            MeleeProt -= removedArmor.Defense;
            RangedProt -= removedArmor.Defense;
            MagicProt -= removedArmor.Defense;

            removedArmor.SlotOnChar = ArmorSlotOnChar.Unequipped; //not equipped anymore
        }
        
        // WEAPONS ---------------------------
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

        public void EquipWeapon(Weapon weapon, bool primary)
        {
            var primaryWeapon = Weapons.FirstOrDefault(w => w.EquippedWeaponSlot == WeaponSlot.Primary);
            var secondaryWeapon = Weapons.FirstOrDefault(w => w.EquippedWeaponSlot == WeaponSlot.Secondary);

            if (primaryWeapon != null && primaryWeapon.Id == weapon.Id)
            {
                if (primary) return; // asked to equip the same weapon that is already equipped in the same slot.
                
                //asked to equip current primary into secondary ---
                if (secondaryWeapon is not null)
                    secondaryWeapon.EquippedWeaponSlot = WeaponSlot.NotEquipped;
                
                primaryWeapon.EquippedWeaponSlot = WeaponSlot.Secondary;
            }

            if (secondaryWeapon != null && secondaryWeapon.Id == weapon.Id)
            {
                if (!primary) return; //asked to equip current secondary into secondary; no action required.

                //asked to equip current secondary into primary --
                if (primaryWeapon is not null)
                    primaryWeapon.EquippedWeaponSlot = WeaponSlot.NotEquipped;

                secondaryWeapon.EquippedWeaponSlot = WeaponSlot.Primary;
            }

            if (primary)
            {
                if (primaryWeapon is not null) primaryWeapon.EquippedWeaponSlot = WeaponSlot.NotEquipped;
                weapon.EquippedWeaponSlot = WeaponSlot.Primary;
            }
            else
            {
                if (secondaryWeapon is not null) secondaryWeapon.EquippedWeaponSlot = WeaponSlot.NotEquipped;
                weapon.EquippedWeaponSlot = WeaponSlot.Secondary;
            }
        }

        public void RemoveWeapon(bool primary)
        {
            var weaponToRemove = Weapons.FirstOrDefault(w =>
                w.EquippedWeaponSlot == (primary ? WeaponSlot.Primary : WeaponSlot.Secondary));
            if (weaponToRemove is null) return;
            
            weaponToRemove.EquippedWeaponSlot = WeaponSlot.NotEquipped;
        }
        
        // MONSTERS ---------------------------
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
}