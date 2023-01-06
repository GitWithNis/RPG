using RPG.Models.Enums;

namespace RPG.Models
{
    public class Effect
    {
        public EffectType EffectType { get; set; }
        public decimal AffectAmt { get; set; } = 0.00m;
    }
}