using World;

namespace Actors.States {
	public class IdleState : ActorState {
		public IdleState(Actor owner) : base(owner) { }

		protected override float UpdatePriority() {
			if ( Owner.IsInside(AreaType.Home) ) {
				var hunger    = Model.CompensatedHunger;
				var settings  = Settings.Idle;
				var maxHunger = settings.MaxCompensatedHunger;
				return settings.Clamp(1 - hunger / maxHunger);
			}
			return 0.0f;
		}

		public override bool Update() => true;
	}
}