using Holders;
using Sources;
using World;

namespace Actors.States {
	public class CollectFoodState : ActorState {
		Area       _area;
		FoodSource _source;
		
		public CollectFoodState(Actor owner) : base(owner) { }
		
		public override float UpdatePriority() {
			_area = Owner.GetAreaInside(AreaType.Food);
			if ( _area ) {
				var holder = _area.GetComponent<FoodSourceHolder>();
				if ( holder ) {
					_source = holder.GetNearest(Owner.transform.position);
					if ( _source ) {
						return 1.0f;
					}
				}
			}
			return 0.0f;
		}

		public override void OnEnter() {
			Owner.Agent.destination = _source.transform.position;
		}

		public override void OnExit() {
			Owner.Agent.ResetPath();
		}

		public override bool Update() {
			return !_source;
		}
	}
}