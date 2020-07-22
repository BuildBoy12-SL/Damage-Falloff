using Exiled.Events.EventArgs;

namespace DamageFalloff
{
    public class EventHandlers
	{
		private readonly DamageFalloff plugin;
		public EventHandlers(DamageFalloff plugin) => this.plugin = plugin;

		public void OnLateShoot(ShotEventArgs ev)
		{
			ev.Damage = plugin.DistanceLogic.DoMath(ev.Damage, ev.Distance, ev.Shooter.ReferenceHub);
		}
	}
}