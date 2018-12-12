using World;

namespace Actors.States {	
	public class GoToFoodState : ActorState {
		Area _foodArea;
		
		public GoToFoodState(Actor owner) : base(owner) { }
		
		protected override float UpdatePriority() {
			_foodArea = Owner.Areas.GetNearestAreaWithType(AreaType.Food, Owner.transform.position);
			if ( (_foodArea != null) && !Owner.IsInside(_foodArea) ) {
				var hunger    = Model.CompensatedHunger;
				var settings  = Settings.GoToFood;
				return settings.FromCompHunger.Evaluate(hunger);
			}
			return 0.0f;
		}

		public override void OnEnter() {
			Owner.Agent.destination = _foodArea.transform.position;
		}

		public override void OnExit() {
			Owner.Agent.ResetPath();
		}

		public override bool Update() {
			return Owner.IsInside(_foodArea);
		}
	}
}