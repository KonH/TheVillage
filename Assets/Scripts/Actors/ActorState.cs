using UDBase.Helpers;
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
			value += CalculateIfInside(Model.Hunger, settings.RealHunger, settings.RealHungerLimits);
			value += CalculateIfInside(Model.NormalizedFoodRestore, settings.FoodRestore, settings.FoodRestoreLimits);
			value += CalculateIfInside(1 - Model.NormalizedFoodRestore, settings.InverseFoodRestore, settings.InverseFoodRestoreLimits);
			value += CalculateIfInside(Model.Stress, settings.Stress, settings.StressLimits);
			value += CalculateIfInside(Model.NormalizedGold, settings.Gold, settings.GoldLimits);
			value = value / 4;
			return value;
		}

		float CalculateIfInside(float value, float coeff, FloatRange interval) {
			return interval.Contains(value) ? value * coeff : 0.0f;
		}
	}
}