using RPG.Models.Enums;

namespace RPG.Dtos.Characters
{
    public class EquipArmorDto
    {
        public int CharId { get; set; }
        public int ArmorId { get; set; }

        //0 for first finger, 1 for second finger
        public int FingerIfRing { get; set; } = 0;
    }
}
