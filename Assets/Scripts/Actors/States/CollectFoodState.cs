using World;
using Holders;
using Sources;

namespace Actors.States {
	public class CollectFoodState : ActorState {
		FoodSource _source;
		
		public CollectFoodState(Actor owner) : base(owner) { }
		
		protected override float UpdatePriority() {
			if ( GetTargetSource() != null ) {
				var hunger    = Model.CompensatedHunger;
				var settings  = Settings.CollectFood;
				return settings.FromCompHunger.Evaluate(hunger);
			}
			return 0.0f;
		}
		
		public override void OnEnter() {
			_source = GetTargetSource();
			Owner.Agent.destination = _source.transform.position;
		}

		public override void OnExit() {
			_source = null;
			Owner.Agent.ResetPath();
		}

		public override bool Update() {
			return !_source;
		}
		
		FoodSource GetTargetSource() {
			var area = Owner.GetAreaInside(AreaType.Food);
			if ( area ) {
				var holder = area.GetComponent<FoodSourceHolder>();
				if ( holder ) {
					return holder.GetNearest(Owner.transform.position);
				}
			}
			return null;
		}
	}
}