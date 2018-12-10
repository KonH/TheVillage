using World;

namespace Actors {
	public abstract class ActorState {
		protected Actor Owner { get; }

		protected ActorState(Actor owner) {
			Owner = owner;
		}

		public virtual void OnEnter() {}
		public virtual void OnExit() {}
		
		public abstract float UpdatePriority();
		public abstract bool Update();
	}
}