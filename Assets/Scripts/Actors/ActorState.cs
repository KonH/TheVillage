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
			var nodes = settings.Nodes;
			var count = 0;
			foreach ( var node in nodes ) {
				var wantedParam = SelectParam(node.Parameter);
				if ( node.Inversed ) {
					wantedParam = (1 - wantedParam);
				}
				if ( (wantedParam >= node.Min) && (wantedParam <= node.Max) ) {
					var curValue = wantedParam * node.Value;
					value += curValue;
					count++;
				}
			}
			value = (count > 0) ? (value * settings.Base) / count : 0.0f;
			return value;
		}

		float SelectParam(ActorSettings.Parameter param) {
			switch ( param ) {
				case ActorSettings.Parameter.RealHunger:  return Model.Hunger;
				case ActorSettings.Parameter.FoodRestore: return Model.NormalizedFoodRestore;
				case ActorSettings.Parameter.Stress:      return Model.Stress;
				case ActorSettings.Parameter.Gold:        return Model.Gold;
				default:                                  return 0.0f;
			}
		}
		
		float CalculateIfInside(float value, float coeff, FloatRange interval) {
			return interval.Contains(value) ? value * coeff : 0.0f;
		}
	}
}