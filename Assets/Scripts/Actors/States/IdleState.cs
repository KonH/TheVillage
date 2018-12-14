using World;

namespace Actors.States {
	public class IdleState : InsideAreaActorState {
		public IdleState(Actor owner) : base(owner, AreaType.Home) { }

		protected override float UpdatePriority() => Calculate(Settings.Idle);

		public override bool Update() => true;
	}
}