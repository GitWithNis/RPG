using RPG.Models.Enums;

namespace RPG.Dtos.Characters
{
    public class RemoveArmorDto
    {
        public int CharId { get; set; }
        public ArmorSlotOnChar Slot { get; set; }
    }
}
