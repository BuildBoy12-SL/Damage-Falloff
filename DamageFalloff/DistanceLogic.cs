using System;

namespace DamageFalloff
{
    public class DistanceLogic
    {
        private readonly DamageFalloff plugin;
        public DistanceLogic(DamageFalloff plugin) => this.plugin = plugin;

        public float DoMath(float damage, float distance, ReferenceHub shooter)
        {           
            if (distance > plugin.Config.MinimumDistance)
            {
                float RangeMod = float.Parse(plugin.Config.NoScope);
                if (shooter.HasSmallScope()) RangeMod = float.Parse(plugin.Config.SmallScope);
                else if (shooter.HasSniperScope()) RangeMod = float.Parse(plugin.Config.LargeScope);
                return damage * (float)Math.Pow(RangeMod, distance / plugin.Config.DistanceDivider);
            }
            return damage;
        }       
    }
}