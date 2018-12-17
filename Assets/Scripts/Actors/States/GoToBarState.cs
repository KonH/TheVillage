using World;

namespace Actors.States {	
	public class GoToBarState : TargetAreaActorState {		
		public GoToBarState(Actor owner) : base(owner, AreaType.Bar) { }

		protected override float UpdatePriority() => Calculate(Settings.GoToBar);
	}
}