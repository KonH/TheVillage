using System.Linq;
using UnityEngine;
using World;
using Models;

namespace Actors.States {
	public class EatFoodState : InsideAreaActorState {
		readonly float _eatTime;

		float         _timer;
		FoodItemModel _food;

		public EatFoodState(Actor owner, float time) : base(owner, AreaType.Home) {
			_eatTime = time;
		}
		
		protected override float UpdatePriority() {
			return (GetFoodItem() != null) ? Calculate(Settings.EatFood) : Unreachable;
		}

		public override void OnEnter() {
			_food  = GetFoodItem();
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