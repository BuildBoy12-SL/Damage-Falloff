using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace DamageFalloff
{
	public class EventHandlers
	{
		public void OnLateShoot(ShotEventArgs ev)
		{
			Log.Info(ev.Damage);
			ev.Damage = DistanceLogic.DoMath(ev.Damage, ev.Distance, ev.Shooter.ReferenceHub);
			Log.Info("Adjusted: " + ev.Damage);
		}
	}
}