using Models;

namespace Actors {
	public abstract class ActorState {
		protected Actor Owner { get; }
		protected ActorModel Model { get; }
		protected ActorSettings Settings { get; }

		protected ActorState(Actor owner) {
			Owner = owner;
			Model = owner.Model;
			Settings = owner.Model.Settings;
		}

		public virtual void OnEnter() {}
		public virtual void OnExit() {}
		
		public abstract float UpdatePriority();
		public abstract bool Update();
	}
}