using World;

namespace Actors.States {
	public class StayInBarState : InsideAreaActorState {
		public StayInBarState(Actor owner) : base(owner, AreaType.Bar) { }

		protected override float UpdatePriority() => Calculate(Settings.StayInBar);

		public override bool Update() => true;
	}
}