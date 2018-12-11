namespace Actors.States {
	public class IdleState : ActorState {
		public IdleState(Actor owner) : base(owner) { }

		protected override float UpdatePriority() {
			var hunger    = Model.Hunger;
			var settings  = Settings.Idle;
			var maxHunger = settings.MaxHunger;
			return settings.Clamp(1 - hunger / maxHunger);
		}

		public override bool Update() => true;
	}
}