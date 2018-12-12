using World;

namespace Actors.States {	
	public class GoToFoodState : TargetAreaActorState {		
		public GoToFoodState(Actor owner) : base(owner, AreaType.Food) { }
		
		protected override float UpdatePriority() {
			var hunger    = Model.CompensatedHunger;
			var settings  = Settings.GoToFood;
			return settings.FromCompHunger.Evaluate(hunger);
		}
	}
}