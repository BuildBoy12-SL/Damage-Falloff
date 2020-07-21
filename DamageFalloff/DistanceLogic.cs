using System;

namespace DamageFalloff
{
    internal class DistanceLogic
    {
        public static float DoMath(float damage, float distance, ReferenceHub shooter)
        {           
            if (distance > DamageFalloff.ConfigRef.Config.MinimumDistance)
            {
                float RangeMod;
                if (shooter.HasSmallScope()) RangeMod = float.Parse(DamageFalloff.ConfigRef.Config.SmallScope);
                else if (shooter.HasSniperScope()) RangeMod = float.Parse(DamageFalloff.ConfigRef.Config.LargeScope);
                else RangeMod = float.Parse(DamageFalloff.ConfigRef.Config.NoScope);
                return damage * (float)Math.Pow(RangeMod, distance / DamageFalloff.ConfigRef.Config.DistanceDivider);
            }
            return damage;
        }       
    }
}
