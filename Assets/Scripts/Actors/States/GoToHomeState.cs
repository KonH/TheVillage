using World;

namespace Actors.States {	
	public class GoToHomeState : ActorState {
		Area _homeArea;
		
		public GoToHomeState(Actor owner) : base(owner) { }
		
		protected override float UpdatePriority() {
			_homeArea = Owner.Areas.GetNearestAreaWithType(AreaType.Home, Owner.transform.position);
			if ( (_homeArea != null) && !Owner.IsInside(_homeArea) ) {
				var hunger    = Model.CompensatedHunger;
				var settings  = Settings.GoToHome;
				return settings.FromCompHunger.Evaluate(hunger);
			}
			return 0.0f;
		}

		public override void OnEnter() {
			Owner.Agent.destination = _homeArea.transform.position;
		}

		public override void OnExit() {
			Owner.Agent.ResetPath();
		}

		public override bool Update() {
			return Owner.IsInside(_homeArea);
		}
	}
}