namespace DamageFalloff
{
    public static class Extensions
    {
        public static bool HasSmallScope(this ReferenceHub rh)
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

        public static bool HasSniperScope(this ReferenceHub rh)
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
