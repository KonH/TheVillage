using World;

namespace Actors.States {	
	public class GoToHomeState : TargetAreaActorState {		
		public GoToHomeState(Actor owner) : base(owner, AreaType.Home) { }
		
		protected override float UpdatePriority() {
			var hunger    = Model.CompensatedHunger;
			var settings  = Settings.GoToHome;
			return settings.FromCompHunger.Evaluate(hunger);
		}
	}
}