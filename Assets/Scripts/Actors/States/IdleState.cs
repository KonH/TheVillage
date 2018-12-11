using UnityEngine;

namespace Actors.States {
	public class IdleState : ActorState {
		public IdleState(Actor owner) : base(owner) { }

		public override float UpdatePriority() {
			var hunger    = Model.Hunger;
			var maxHunger = Settings.Idle.MaxHunger;
			return Mathf.Clamp01(1 - hunger / maxHunger);
		}

		public override bool Update() => true;
	}
}