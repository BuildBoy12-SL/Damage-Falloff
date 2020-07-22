using Exiled.API.Features;
using System;

namespace DamageFalloff 
{
	public class DamageFalloff : Plugin<Config>
	{
		public EventHandlers EventHandlers;
		public DistanceLogic DistanceLogic;

		public override void OnEnabled()
		{
			base.OnEnabled();
			EventHandlers = new EventHandlers(this);
			DistanceLogic = new DistanceLogic(this);
			Exiled.Events.Handlers.Player.Shot += EventHandlers.OnLateShoot;		
		}

		public override void OnDisabled()
		{
			Exiled.Events.Handlers.Player.Shot -= EventHandlers.OnLateShoot;
			EventHandlers = null;
			DistanceLogic = null;
		}

		public override string Name => "Damage Falloff";
        public override string Author => "Build"; 
	}
}