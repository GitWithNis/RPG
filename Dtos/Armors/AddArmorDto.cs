using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG.Models.Enums;

namespace RPG.Dtos.Armors
{
    public class AddArmorDto
    {
        public int CharacterId { get; set; }
        public string Name { get; set; } = "Nameless Armor";
        public int Defense { get; set; }
        public int Protection { get; set; }
        public ArmorSlot Slot { get; set; }
        public Material Material { get; set; }
        public decimal MeleeProt { get; set; } = 0;
        public decimal RangeProt { get; set; } = 0;
        public decimal MagicProt { get; set; } = 0;
    }
}