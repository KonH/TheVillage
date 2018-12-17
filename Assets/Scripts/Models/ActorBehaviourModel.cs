using Zenject;

namespace Models {
	public class ActorBehaviourModel {
		public float StartHunger           { get; }
		public float StartStress           { get; }
		public int   StartGold             { get; }
		public float EatDesire             { get; }
		public float OwnedFoodSatisfaction { get; }
		public float StressIncrease        { get; }
		public float StressRestore         { get; }
		public int   Greedy                { get; }

		public ActorBehaviourModel(ActorSettings settings) {
			StartHunger           = settings.StartHunger.Random();
			StartStress           = settings.StartStress.Random();
			StartGold             = settings.StartGold.Random();
			EatDesire             = settings.EatDesire.Random();
			OwnedFoodSatisfaction = settings.OwnedFoodSatisfaction.Random();
			StressIncrease        = settings.StressIncrease.Random();
			StressRestore         = settings.StressRestore.Random();
			Greedy                = settings.Greedy.Random();
		}
		
		public class Factory : PlaceholderFactory<ActorBehaviourModel> {}
	}
}