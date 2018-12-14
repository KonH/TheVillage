using Models;

namespace Actors {
	public abstract class ActorState {
		protected const float Unreachable = -1.1f;
		
		public string Name     { get; }
		public float  Priority { get; private set; }

		protected Actor         Owner    { get; }
		protected ActorModel    Model    { get; }
		protected ActorSettings Settings { get; }
		
		protected ActorState(Actor owner) {
			Name     = GetType().Name;
			Owner    = owner;
			Model    = owner.Model;
			Settings = Owner.Settings;
		}
		
		public virtual float RefreshPriority() {
			return SavePriority(UpdatePriority());
		}
		
		public virtual void OnEnter() {}
		public virtual void OnExit() {}

		public abstract bool Update();

		protected abstract float UpdatePriority();

		protected float SavePriority(float value) {
			Priority = value;
			return Priority;
		}
		
		protected float Calculate(ActorSettings.StateSettings settings) {
			var value = 0.0f;
			value += Model.Hunger * settings.RealHunger;
			value += Model.NormalizedFoodRestore * settings.FoodRestore;
			value += Model.Stress * settings.Stress;
			value = value / 3;
			return value;
		}
	}
}