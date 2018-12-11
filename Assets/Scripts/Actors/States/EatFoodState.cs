using System.Linq;
using Models;
using UnityEngine;

namespace Actors.States {
	public class EatFoodState : ActorState {
		readonly float EatTime;

		float _timer;
		FoodItemModel _food;

		public EatFoodState(Actor owner, float time) : base(owner) {
			EatTime = time;
		}
		
		public override float UpdatePriority() {
			_food = Owner.Model.Inventory.FirstOrDefault(item => item is FoodItemModel) as FoodItemModel;
			 if ( _food != null ) {
				 var hunger    = Model.Hunger;
				 var minHunger = Settings.EatFood.MinHunger;
				 return Mathf.Clamp01((hunger - minHunger) / (1 - minHunger));
			 }
			return 0.0f;
		}

		public override void OnEnter() {
			_timer = 0.0f;
		}

		public override bool Update() {
			if ( _timer > EatTime ) {
				_food.UseBy(Owner.Model);
				Owner.Model.Inventory.Remove(_food);
				_food = null;
			} else {
				_timer += Time.deltaTime;
			}
			return _food != null;
		}
	}
}