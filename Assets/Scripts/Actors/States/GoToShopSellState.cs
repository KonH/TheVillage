using World;

namespace Actors.States {	
	public class GoToShopSellState : TargetAreaActorState {		
		public GoToShopSellState(Actor owner) : base(owner, AreaType.Shop) { }

		protected override float UpdatePriority() => Calculate(Settings.GoToShopSell);
	}
}