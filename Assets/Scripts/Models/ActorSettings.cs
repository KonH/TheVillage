using System;
using UnityEngine;

namespace Models {
	[Serializable]
	public class ActorSettings {
		public class BaseSettings {
			public AnimationCurve FromCompHunger;
		}
		
		[Serializable]
		public class GoToHomeSettings : BaseSettings {
		}
		
		[Serializable]
		public class IdleSettings : BaseSettings {
		}
		
		[Serializable]
		public class GoToFoodSettings : BaseSettings {
		}

		[Serializable]
		public class CollectFoodSettings : BaseSettings {
		}
		
		[Serializable]
		public class EatFoodSettings {
			[Range(0, 1)] public float HomeCoeff;
			public AnimationCurve FromHunger;
		}

		[Range(0, 1)] public float StartHunger;
		[Range(0, 1)] public float CompHungerCoeff;
		
		public GoToHomeSettings GoToHome;
		public IdleSettings Idle;
		public GoToFoodSettings GoToFood;
		public CollectFoodSettings CollectFood;
		public EatFoodSettings EatFood;
	}
}