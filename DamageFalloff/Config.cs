using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DamageFalloff
{
    public class Config : IConfig
    {
        [Description("Minimum distance for falloff to activate.")]
        public int MinimumDistance { get; set; } = 10;

        [Description("Denominator when calculating the exponent to RangeMod.")]
        public int DistanceDivider { get; set; } = 10;

        /// <summary>
        /// Don't patronize me for using strings for these three, the config writer made it look ugly so this makes it look pretty.
        /// </summary>
        [Description("Multiplier when the shooter has no scope.")]
        public string NoScope { get; set; } = "0.85";

        [Description("Multiplier when the shooter has a red/blue dot or holo sight.")]
        public string SmallScope { get; set; } = "0.90";

        [Description("Multiplier when the shooter has a night vision or sniper sight.")]
        public string LargeScope { get; set; } = "0.95";

        [Description("Note the formula used is \"Damage [Multiplier ^ (Distance/DistanceDivider)]\"")]
        public bool IsEnabled { get; set; } = true;
    }
}
