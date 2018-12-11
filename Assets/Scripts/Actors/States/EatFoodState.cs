using System.Linq;
using Models;

namespace Actors.States {
	public class EatFoodState : ActorState {
		readonly float Time;
		
		FoodItemModel _food;
		bool _done;

		public EatFoodState(Actor owner, float time) : base(owner) {
			Time = time;
		}
		
		public override float UpdatePriority() {
			_food = Owner.Model.Inventory.FirstOrDefault(item => item is FoodItemModel) as FoodItemModel;
			return (_food != null) ? 1.0f : 0.0f;
		}

		public override void OnEnter() {
			_done = false;
			Owner.Schedule(Time, () => _done = true);
		}

		public override void OnExit() {
			Owner.Model.Inventory.Remove(_food);
		}

		public override bool Update() {
			return _done;
		}
	}
}