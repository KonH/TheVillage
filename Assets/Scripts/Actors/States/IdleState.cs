using World;

namespace Actors.States {
	public class IdleState : InsideAreaActorState {
		public IdleState(Actor owner) : base(owner, AreaType.Home) { }

		protected override float UpdatePriority() {
			var hunger    = Model.CompensatedHunger;
			var settings  = Settings.Idle;
			return settings.FromCompHunger.Evaluate(hunger);
		}

		public override bool Update() => true;
	}
}