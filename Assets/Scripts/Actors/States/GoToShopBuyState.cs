using World;

namespace Actors.States {	
	public class GoToShopBuyState : TargetAreaActorState {		
		public GoToShopBuyState(Actor owner) : base(owner, AreaType.Shop) { }

		protected override float UpdatePriority() => Calculate(Settings.GoToShopBuy);
	}
}