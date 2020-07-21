using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace DamageFalloff
{
	public class EventHandlers
	{
		public void OnLateShoot(ShotEventArgs ev)
		{
			ev.Damage = DistanceLogic.DoMath(ev.Damage, ev.Distance, ev.Shooter.ReferenceHub);
		}
	}
}