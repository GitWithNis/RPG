using System.Text.Json.Serialization;

namespace RPG.Models.Enums
{
    //for swaggerUI to actually display the enum instead of 0, 1, 2, etc.
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ArmorSlot
    {
        Head,
        Neck,
        Chest,
        Hands,
        Fingers,
        Legs,
        Feet
    }
}