using Holders;
using Models;
using World;

namespace Actors.States {	
	public class GoToShopBuyState : TargetAreaActorState {		
		public GoToShopBuyState(Actor owner) : base(owner, AreaType.Shop) { }

		protected override float UpdatePriority() {
			var area = GetTargetArea();
			var holder = area.GetComponent<ItemHolder>();
			if ( holder && (holder.Peek(item => item is FoodItemModel) != null) ) {
				return Calculate(Settings.GoToShopBuy);
			}
			return Unreachable;
		}
	}
}