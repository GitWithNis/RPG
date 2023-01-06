using System.Text.Json.Serialization;

namespace RPG.Models.Enums
{
    //for swaggerUI to actually display the enum instead of 0, 1, 2, etc.
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum CharacterClass
    {
        Warrior = 1,
        Knight = 2,
        Rogue = 3,
        Archer = 4,
        Cleric = 5,
        Wizard = 6

    }
}