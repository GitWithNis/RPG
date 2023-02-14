using System.Text.Json.Serialization;

namespace RPG.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ArmorSlotOnChar
    {
        Unequipped,
        Head,
        Neck,
        Chest,
        Hands,
        Legs,
        Feet,
        FingerL,
        FingerR
    }
}