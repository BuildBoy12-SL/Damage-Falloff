using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace DamageFalloff
{
    public class EventHandlers
	{
		private readonly DamageFalloff plugin;
		public EventHandlers(DamageFalloff plugin) => this.plugin = plugin;

		public void OnLateShoot(ShotEventArgs ev)
		{
			Player target = Player.Get(ev.Target);
			ev.CanHurt = false;
			target.ReferenceHub.playerStats.HurtPlayer(new PlayerStats.HitInfo(plugin.DistanceLogic.DoMath(ev.Damage, ev.Distance, ev.Shooter.ReferenceHub), ev.Shooter.Nickname, WeapontoDamageType(ev.Shooter.ReferenceHub.inventory.curItem), ev.Shooter.Id), target.GameObject, false);
		}

		private DamageTypes.DamageType WeapontoDamageType(ItemType item)
        {
			if (item == ItemType.GunCOM15) return DamageTypes.Com15;
			else if (item == ItemType.GunE11SR) return DamageTypes.E11StandardRifle;
			else if (item == ItemType.GunLogicer) return DamageTypes.Logicer;
			else if (item == ItemType.GunMP7) return DamageTypes.Mp7;
			else if (item == ItemType.GunProject90) return DamageTypes.P90;
			else if (item == ItemType.GunUSP) return DamageTypes.Usp;
			return DamageTypes.Wall;
        }
	}
}