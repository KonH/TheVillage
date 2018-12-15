using System.Linq;
using Holders;
using UnityEngine;
using World;
using Models;

namespace Actors.States {
	public class SellFoodState : InsideAreaActorState {
		readonly float _sellTime;

		float _timer;

		public SellFoodState(Actor owner, float time) : base(owner, AreaType.Shop) {
			_sellTime = time;
		}
		
		protected override float UpdatePriority() {
			return (GetFoodItem() != null) ? Calculate(Settings.SellFood) : Unreachable;
		}

		public override void OnEnter() {
			base.OnEnter();
			_timer = 0.0f;
			var holder = InsideArea.GetComponent<ItemHolder>();
			holder.Add(GetFoodItem(), Model);
		}

		public override bool Update() {
			_timer += Time.deltaTime;
			return (_timer > _sellTime);
		}

		ItemModel GetFoodItem() {
			return Model.Inventory.FirstOrDefault(item => item is FoodItemModel);
		}
	}
}