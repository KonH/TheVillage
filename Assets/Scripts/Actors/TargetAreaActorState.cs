using World;

namespace Actors {
	public abstract class TargetAreaActorState : ActorState {
		protected Area TargetArea;
		
		readonly AreaType Type;

		protected TargetAreaActorState(Actor owner, AreaType type) : base(owner) {
			Type = type;
		}

		public override float RefreshPriority() {
			return SavePriority((GetTargetArea() != null) ? UpdatePriority() : -1.0f);
		}
		
		public override void OnEnter() {
			TargetArea = GetTargetArea();
			Owner.Agent.destination = TargetArea.transform.position;
		}

		public override void OnExit() {
			TargetArea = null;
			Owner.Agent.ResetPath();
		}

		public override bool Update() {
			return Owner.IsInside(TargetArea);
		}
		
		Area GetTargetArea() {
			var area = Owner.Areas.GetNearestAreaWithType(Type, Owner.transform.position);
			return !Owner.IsInside(area) ? area : null;
		}
	}
}