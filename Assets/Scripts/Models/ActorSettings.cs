using System;

namespace Models {
	[Serializable]
	public class ActorSettings {
		[Serializable]
		public class IdleSettings {
			public float MaxHunger;
		}
		
		[Serializable]
		public class GoToFoodSettings {
			public float MinHunger;
		}

		[Serializable]
		public class CollectFoodSettings {
			public float MinHunger;
		}
		
		[Serializable]
		public class EatFoodSettings {
			public float MinHunger;
		}

		public IdleSettings Idle;
		public GoToFoodSettings GoToFood;
		public CollectFoodSettings CollectFood;
		public EatFoodSettings EatFood;
	}
}