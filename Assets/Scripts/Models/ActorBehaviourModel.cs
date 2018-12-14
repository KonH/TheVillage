using Zenject;

namespace Models {
	public class ActorBehaviourModel {
		public float StartHunger           { get; }
		public float EatDesire             { get; }
		public float OwnedFoodSatisfaction { get; }

		public ActorBehaviourModel(ActorSettings settings) {
			StartHunger           = settings.StartHunger.Random();
			EatDesire             = settings.EatDesire.Random();
			OwnedFoodSatisfaction = settings.OwnedFoodSatisfaction.Random();
		}
		
		public class Factory : Factory<ActorBehaviourModel> {}
	}
}