using World;

namespace Actors.States {
	public class IdleState : ActorState {
		public IdleState(Actor owner) : base(owner) { }

		protected override float UpdatePriority() {
			if ( Owner.IsInside(AreaType.Home) ) {
				var hunger    = Model.CompensatedHunger;
				var settings  = Settings.Idle;
				return settings.FromCompHunger.Evaluate(hunger);
			}
			return 0.0f;
		}

		public override bool Update() => true;
	}
}