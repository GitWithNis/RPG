using RPG.Models.Enums;

namespace RPG.Models
{
    public class Armor
    {
        public string Name { get; set; } = "Nameless Armor";
        public int Defense { get; set; }
        public int Protection { get; set; }
        public ArmorSlot Slot { get; set; }
        public Material Material { get; set; }
        public List<Effect>? Effects { get; set; }
    }
}