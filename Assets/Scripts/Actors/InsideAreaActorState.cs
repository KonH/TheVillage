using World;

namespace Actors {
	public abstract class InsideAreaActorState : ActorState {
		protected Area InsideArea;
		
		readonly AreaType Type;

		protected InsideAreaActorState(Actor owner, AreaType type) : base(owner) {
			Type = type;
		}

		public override float RefreshPriority() {
			return SavePriority(Owner.IsInside(Type) ? UpdatePriority() : -1.0f);
		}
		
		public override void OnEnter() {
			InsideArea = GetAreaInside();
		}

		public override void OnExit() {
			InsideArea = null;
		}

		Area GetAreaInside() {
			return Owner.GetAreaInside(Type);
		}
	}
}