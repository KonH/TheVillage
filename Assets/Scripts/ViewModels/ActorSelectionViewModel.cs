using Models;
using UnityWeld.Binding;

namespace ViewModels {
	[Binding]
	public class ActorSelectionViewModel {
		[Binding] public string Name => _model.Id.Name;

		readonly ActorSelectionListViewModel _parent;
		readonly ActorModel _model;

		public ActorSelectionViewModel(ActorSelectionListViewModel parent, ActorModel model) {
			_parent = parent;
			_model = model;
		}

		[Binding]
		public void OnClick() {
			_parent.OnClick(_model);
		}
	}
}