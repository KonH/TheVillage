using System;
using System.Collections.Generic;
using UDBase.Helpers;
using UnityEngine;

namespace Models {
	[Serializable]
	public class ActorSettings {
		public enum Parameter {
			RealHunger,
			FoodRestore,
			Stress,
			Gold,
		}

		[Serializable]
		public class StateSettingsNode {
			public Parameter Parameter;
			public bool Inversed;
			
			[Range(0, 1)]
			public float Min;
			
			[Range(0, 1)]
			public float Max;
			
			[Range(-1, 1)]
			public float Value;
		}
		
		[Serializable]
		public class StateSettings {
			public List<StateSettingsNode> Nodes;
			
			[Range(0, 1)]
			public float Base;
		}

		[Header("Behaviour")]
		public FloatRange StartHunger;
		public FloatRange StartStress;
		public IntRange   StartGold;
		public FloatRange EatDesire;
		public FloatRange OwnedFoodSatisfaction;
		public FloatRange StressIncrease;
		public FloatRange StressRestore;
		public IntRange   Greedy;

		[Header("States")]
		public StateSettings GoToHome;
		public StateSettings Idle;
		public StateSettings GoToFood;
		public StateSettings CollectFood;
		public StateSettings EatFood;
		public StateSettings GoToShop;
	}
}