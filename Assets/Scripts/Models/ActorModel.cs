using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityWeld.Binding;
using JetBrains.Annotations;

namespace Models {
	public class ActorModel : INotifyPropertyChanged {
		public ActorId             Id        { get; }
		public ActorBehaviourModel Behaviour { get; }
		
		public string State {
			get { return _state; }
			set {
				if ( value == _state ) return;
				_state = value;
				OnPropertyChanged();
			}
		}

		public float Hunger {
			get { return _hunger; }
			set {
				var clampValue = Mathf.Clamp01(value);
				if ( clampValue.Equals(_hunger) ) return;
				_hunger = clampValue;
				OnPropertyChanged();
			}
		}
		
		public float Stress {
			get { return _stress; }
			set {
				var clampValue = Mathf.Clamp01(value);
				if ( clampValue.Equals(_stress) ) return;
				_stress = clampValue;
				OnPropertyChanged();
			}
		}

		public float NormalizedFoodRestore {
			get {
				var restore = Inventory.Sum(item => {
					var food = item as FoodItemModel;
					return (food != null) ? food.Restore : 0.0f;
				});
				return Mathf.Clamp01(restore * Behaviour.OwnedFoodSatisfaction);
			}
		}
		
		public ObservableList<ItemModel> Inventory { get; } = new ObservableList<ItemModel>();

		string _state;
		float  _hunger;
		float  _stress;

		public event PropertyChangedEventHandler PropertyChanged;

		public ActorModel(ActorId id, ActorBehaviourModel behaviour) {
			Id        = id;
			Behaviour = behaviour;
			Hunger    = Behaviour.StartHunger;
			Stress    = Behaviour.StartStress;
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}