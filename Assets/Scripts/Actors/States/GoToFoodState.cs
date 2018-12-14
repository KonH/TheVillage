using World;

namespace Actors.States {
	public class GoToFoodState : TargetAreaActorState {		
		public GoToFoodState(Actor owner) : base(owner, AreaType.Food) { }
		
		protected override float UpdatePriority() => Calculate(Settings.GoToFood);
	}
}