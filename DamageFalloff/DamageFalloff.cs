using Exiled.API.Features;
using System;

namespace DamageFalloff 
{
	public class DamageFalloff : Plugin<Config>
	{
		private static readonly Lazy<DamageFalloff> LazyInstance = new Lazy<DamageFalloff>(() => new DamageFalloff());
		private DamageFalloff() { }
		public static DamageFalloff ConfigRef => LazyInstance.Value;

		private EventHandlers EventHandlers;

		public override void OnEnabled()
		{
			base.OnEnabled();
			EventHandlers = new EventHandlers();
			Exiled.Events.Handlers.Player.Shot += EventHandlers.OnLateShoot;		
		}

		public override void OnDisabled()
		{
			Exiled.Events.Handlers.Player.Shot -= EventHandlers.OnLateShoot;
			EventHandlers = null;
		}

		public override string Name => "Damage Falloff";
        public override string Author => "Build"; 
	}
}