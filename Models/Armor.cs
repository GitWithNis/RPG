using System.Text.Json.Serialization;
using RPG.Models.Enums;

namespace RPG.Models
{
    public class Armor
    {
        public int Id { get; set; }
        
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character? Character { get; set; }
        
        public ArmorSlot Slot { get; set; }
        public ArmorSlotOnChar SlotOnChar { get; set; } = ArmorSlotOnChar.Unequipped;
        
        public string Name { get; set; } = "Nameless Armor";
        public int Defense { get; set; } = 0;
        public int Protection { get; set; } = 0;
        public Material Material { get; set; }
        public decimal MeleeProt { get; set; } = 0;
        public decimal RangeProt { get; set; } = 0;
        public decimal MagicProt { get; set; } = 0;
    }
}