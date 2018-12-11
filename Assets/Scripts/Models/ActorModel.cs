using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityWeld.Binding;

namespace Models {
	public class ActorModel : INotifyPropertyChanged {		
		public ActorSettings Settings { get; }
		
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

		public ObservableList<ItemModel> Inventory { get; } = new ObservableList<ItemModel>();

		string _state;

		float _hunger;

		public event PropertyChangedEventHandler PropertyChanged;

		public ActorModel(ActorSettings settings) {
			Settings = settings;
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}