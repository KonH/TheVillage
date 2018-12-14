using World;

namespace Actors.States {	
	public class GoToHomeState : TargetAreaActorState {		
		public GoToHomeState(Actor owner) : base(owner, AreaType.Home) { }

		protected override float UpdatePriority() => Calculate(Settings.GoToHome);
	}
}