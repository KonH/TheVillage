namespace Actors.States {
	public class IdleState : ActorState {
		public IdleState(Actor owner) : base(owner) { }

		public override float UpdatePriority() => 0.01f;
		public override bool Update() => true;
	}
}