using System;
using UDBase.Helpers;
using UnityEngine;

namespace Models {
	[Serializable]
	public class ActorSettings {
		[Serializable]
		public class StateSettings {
			public FloatRange RealHungerLimits;
			
			[Range(-1, 1)]
			public float RealHunger;

			public FloatRange FoodRestoreLimits;
			
			[Range(-1, 1)]
			public float FoodRestore;

			public FloatRange StressLimits;
			
			[Range(-1, 1)]
			public float Stress;
		}

		[Header("Behaviour")]
		public FloatRange StartHunger;
		public FloatRange StartStress;
		public FloatRange EatDesire;
		public FloatRange OwnedFoodSatisfaction;
		public FloatRange StressIncrease;
		public FloatRange StressRestore;

		[Header("States")]
		public StateSettings GoToHome;
		public StateSettings Idle;
		public StateSettings GoToFood;
		public StateSettings CollectFood;
		public StateSettings EatFood;
	}
}