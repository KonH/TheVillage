using System;
using UDBase.Helpers;
using UnityEngine;

namespace Models {
	[Serializable]
	public class ActorSettings {
		[Serializable]
		public class StateSettings {
			[Range(-1, 1)] public float RealHunger;
			[Range(-1, 1)] public float FoodRestore;
		}

		[Header("Behaviour")]
		public FloatRange StartHunger;
		public FloatRange EatDesire;
		public FloatRange OwnedFoodSatisfaction;

		[Header("States")]
		public StateSettings GoToHome;
		public StateSettings Idle;
		public StateSettings GoToFood;
		public StateSettings CollectFood;
		public StateSettings EatFood;
	}
}