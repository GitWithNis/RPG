using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG.Models;

namespace RPG.Dtos.Characters
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = "Nameless";
        public int MaxHP { get; set; } = 100;
        public int HP { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public CharacterClass Class { get; set; } = CharacterClass.Warrior;
    }
}