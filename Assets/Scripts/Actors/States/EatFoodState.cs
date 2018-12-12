using System.Linq;
using Models;
using UnityEngine;

namespace Actors.States {
	public class EatFoodState : ActorState {
		readonly float _eatTime;

		float _timer;
		FoodItemModel _food;

		public EatFoodState(Actor owner, float time) : base(owner) {
			_eatTime = time;
		}
		
		protected override float UpdatePriority() {
			_food = Owner.Model.Inventory.FirstOrDefault(item => item is FoodItemModel) as FoodItemModel;
			 if ( _food != null ) {
				 var hunger    = Model.Hunger;
				 var settings  = Settings.EatFood;
				 return settings.FromHunger.Evaluate(hunger);
			 }
			return 0.0f;
		}

		public override void OnEnter() {
			_timer = 0.0f;
		}

		public override bool Update() {
			if ( _timer > _eatTime ) {
				_food.UseBy(Owner.Model);
				Owner.Model.Inventory.Remove(_food);
				_food = null;
			} else {
				_timer += Time.deltaTime;
			}
			return (_food == null);
		}
	}
}