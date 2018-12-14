using Zenject;

namespace Models {
	public class ActorBehaviourModel {
		public float StartHunger           { get; }
		public float StartStress           { get; }
		public float EatDesire             { get; }
		public float OwnedFoodSatisfaction { get; }
		public float StressIncrease        { get; }
		public float StressRestore         { get; }

		public ActorBehaviourModel(ActorSettings settings) {
			StartHunger           = settings.StartHunger.Random();
			StartStress           = settings.StartStress.Random();
			EatDesire             = settings.EatDesire.Random();
			OwnedFoodSatisfaction = settings.OwnedFoodSatisfaction.Random();
			StressIncrease        = settings.StressIncrease.Random();
			StressRestore         = settings.StressRestore.Random();
		}
		
		public class Factory : Factory<ActorBehaviourModel> {}
	}
}