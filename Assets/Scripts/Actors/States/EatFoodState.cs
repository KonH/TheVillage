using System.Linq;
using Models;
using UnityEngine;
using World;

namespace Actors.States {
	public class EatFoodState : ActorState {
		readonly float _eatTime;

		float _timer;
		FoodItemModel _food;

		public EatFoodState(Actor owner, float time) : base(owner) {
			_eatTime = time;
		}
		
		protected override float UpdatePriority() {
			 if ( GetFoodItem() != null ) {
				 var hunger    = Model.Hunger;
				 var settings  = Settings.EatFood;
				 var inHome    = Owner.IsInside(AreaType.Home) ? settings.HomeCoeff : 0.0f;
				 return Avg(settings.FromHunger.Evaluate(hunger), inHome);
			 }
			return 0.0f;
		}

		public override void OnEnter() {
			_food = GetFoodItem();
			_timer = 0.0f;
		}

		public override void OnExit() {
			_food = null;
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

		FoodItemModel GetFoodItem() {
			return Owner.Model.Inventory.FirstOrDefault(item => item is FoodItemModel) as FoodItemModel;
		}
	}
}