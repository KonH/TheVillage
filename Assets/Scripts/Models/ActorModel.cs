using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityWeld.Binding;

namespace Models {
	public class ActorModel : INotifyPropertyChanged {
		public string State {
			get { return _state; }
			set {
				if ( value == _state ) return;
				_state = value;
				OnPropertyChanged();
			}
		}

		public ObservableList<ItemModel> Inventory { get; } = new ObservableList<ItemModel>();
		
		string _state;

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}