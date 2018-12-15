using Holders;
using UnityEngine;
using World;
using Models;

namespace Actors.States {
	public class BuyFoodState : InsideAreaActorState {
		readonly float _buyTime;

		float _timer;

		public BuyFoodState(Actor owner, float time) : base(owner, AreaType.Shop) {
			_buyTime = time;
		}
		
		protected override float UpdatePriority() {
			return (GetFoodItem() != null) ? Calculate(Settings.BuyFood) : Unreachable;
		}

		public override void OnEnter() {
			base.OnEnter();
			_timer = 0.0f;
			var holder = GetHolder();
			holder.Get(GetFoodItem(), Model);
		}

		public override bool Update() {
			_timer += Time.deltaTime;
			return (_timer > _buyTime);
		}

		ItemHolder GetHolder() {
			var area = GetAreaInside();
			return area ? area.GetComponent<ItemHolder>() : null;
		}
		
		ItemModel GetFoodItem() {
			var holder = GetHolder();
			if ( holder ) {
				var food = holder.Peek(item => item is FoodItemModel);
				if ( (food != null) && (food.Price <= Model.Gold) ) {
					return food;
				}
			}
			return null;
		}
	}
}