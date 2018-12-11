using System;
using UnityEngine;

namespace Models {
	[Serializable]
	public class ActorSettings {
		public class BaseSettings {
			[Range(0, 1)] public float Min;
			[Range(0, 1)] public float Max;

			public float Clamp(float value) => Mathf.Clamp(value, Min, Max);
		}
		
		[Serializable]
		public class GoToHomeSettings : BaseSettings {
			[Range(0, 1)] public float MaxCompensatedHunger;
		}
		
		[Serializable]
		public class IdleSettings : BaseSettings {
			[Range(0, 1)] public float MaxCompensatedHunger;
		}
		
		[Serializable]
		public class GoToFoodSettings : BaseSettings {
			[Range(0, 1)] public float MinCompensatedHunger;
		}

		[Serializable]
		public class CollectFoodSettings : BaseSettings {
			[Range(0, 1)] public float MinCompensatedHunger;
		}
		
		[Serializable]
		public class EatFoodSettings : BaseSettings {
			[Range(0, 1)] public float MinHunger;
		}

		public GoToHomeSettings GoToHome;
		public IdleSettings Idle;
		public GoToFoodSettings GoToFood;
		public CollectFoodSettings CollectFood;
		public EatFoodSettings EatFood;
	}
}