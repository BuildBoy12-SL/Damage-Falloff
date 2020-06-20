using EXILED;

namespace DamageFalloff 
{
	public class Plugin : EXILED.Plugin
	{
		public EventHandlers EventHandlers;
		public DistanceLogic DistanceLogic;

		public bool Enabled;
		public float MinimumDist;
		public float NoSMult;
		public float SmallSMult;
		public float LargeSMult;
		public float MainDiv;

		public float finaldam;

		public override void OnEnable()
		{					
			ReloadConfig();
			if (!Enabled)
				return;

			EventHandlers = new EventHandlers(this);
			DistanceLogic = new DistanceLogic(this);

			Events.LateShootEvent += EventHandlers.OnLateShoot;

			Log.Info($"Damage Falloff loaded successfully.");		
		}

		public override void OnDisable()
		{
			Events.LateShootEvent -= EventHandlers.OnLateShoot;

			EventHandlers = null;
			DistanceLogic = null;
		}

		public override void OnReload()
		{
			
		}

		public override string getName { get; } = "Damage Falloff";

		public void ReloadConfig()
		{
			Enabled = Config.GetBool("DmgFall_Enabled", true);
			MinimumDist = Config.GetFloat("DmgFall_MinDist", 10F);
			NoSMult = Config.GetFloat("DmgFall_NoScope", .85F);
			SmallSMult = Config.GetFloat("DmgFall_SmallScope", .9F);
			LargeSMult = Config.GetFloat("DmgFall_LargeScope", .95F);
			MainDiv = Config.GetFloat("DmgFall_DistanceDiv", 10F);
		}
	}
}