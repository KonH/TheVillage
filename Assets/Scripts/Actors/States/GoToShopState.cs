using World;

namespace Actors.States {	
	public class GoToShopState : TargetAreaActorState {		
		public GoToShopState(Actor owner) : base(owner, AreaType.Shop) { }

		protected override float UpdatePriority() => Calculate(Settings.GoToHome);
	}
}