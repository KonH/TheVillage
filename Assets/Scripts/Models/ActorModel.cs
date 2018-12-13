using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityWeld.Binding;

namespace Models {
	public class ActorModel : INotifyPropertyChanged {		
		public ActorSettings Settings { get; }
		
		public ActorId Id { get; }
		
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

		public float CompensatedHunger {
			get {
				var restore = Inventory.Sum(item => {
					var food = item as FoodItemModel;
					return (food != null) ? food.Restore : 0.0f;
				});
				return Hunger - restore * Settings.CompHungerCoeff;
			}
		}
		
		public ObservableList<ItemModel> Inventory { get; } = new ObservableList<ItemModel>();

		string _state;
		float _hunger;

		public event PropertyChangedEventHandler PropertyChanged;

		public ActorModel(ActorId id, ActorSettings settings) {
			Id = id;
			Settings = settings;
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}