using System;

namespace DamageFalloff
{
    public class DistanceLogic
    {
        private readonly Plugin plugin;
        public DistanceLogic(Plugin plugin) => this.plugin = plugin;

        float RangeMod;

        public void DoMath(float damage, float distance, ReferenceHub shooter)
        {
            if (distance > plugin.MinimumDist)
            {
                if (HasSmallScope(shooter))
                {
                    RangeMod = plugin.SmallSMult;
                }
                if (HasSniperScope(shooter))
                {
                    RangeMod = plugin.LargeSMult;
                }
                else
                {
                    RangeMod = plugin.NoSMult;
                }
                float DD = distance / plugin.MainDiv;
                double pow = Math.Pow(RangeMod, DD);
                float powf = (float)pow;
                plugin.finaldam = damage * powf;
            }
            else
            {
                plugin.finaldam = damage;
            }
        }

        public bool HasSmallScope(ReferenceHub rh)
        {
            if (rh.inventory == null || rh.weaponManager == null || !rh.weaponManager.NetworksyncFlash ||
                rh.weaponManager.curWeapon < 0 ||
                rh.weaponManager.curWeapon >= rh.weaponManager.weapons.Length) return false;
            WeaponManager.Weapon weapon = rh.weaponManager.weapons[rh.weaponManager.curWeapon];
            Inventory.SyncItemInfo itemInHand = rh.inventory.GetItemInHand();
            if (weapon == null || itemInHand.modSight < 0 || itemInHand.modSight >= weapon.mod_sights.Length)
                return false;
            WeaponManager.Weapon.WeaponMod modScope = weapon.mod_sights[itemInHand.modSight];
            if (modScope != null && !string.IsNullOrEmpty(modScope.name) && (modScope.name.ToLower().Contains("dot") || modScope.name.Contains("holo")))
                return true;
            return false;
        }

        public bool HasSniperScope(ReferenceHub rh)
        {
            if (rh.inventory == null || rh.weaponManager == null || !rh.weaponManager.NetworksyncFlash ||
                rh.weaponManager.curWeapon < 0 ||
                rh.weaponManager.curWeapon >= rh.weaponManager.weapons.Length) return false;
            WeaponManager.Weapon weapon = rh.weaponManager.weapons[rh.weaponManager.curWeapon];
            Inventory.SyncItemInfo itemInHand = rh.inventory.GetItemInHand();
            if (weapon == null || itemInHand.modSight < 0 || itemInHand.modSight >= weapon.mod_sights.Length)
                return false;
            WeaponManager.Weapon.WeaponMod modScope = weapon.mod_sights[itemInHand.modSight];
            if (modScope != null && !string.IsNullOrEmpty(modScope.name) && (modScope.name.ToLower().Contains("sniper") || modScope.name.Contains("night")))
                return true;
            return false;
        }
    }
}
