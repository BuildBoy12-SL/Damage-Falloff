using EXILED;

namespace DamageFalloff
{
	public class EventHandlers
	{
		private readonly Plugin plugin;
		public EventHandlers(Plugin plugin) => this.plugin = plugin;

		public void OnLateShoot(ref LateShootEvent ev)
		{
			plugin.DistanceLogic.DoMath(ev.Damage, ev.Distance, ev.Shooter);
			ev.Damage = plugin.finaldam;
		}
	}
}