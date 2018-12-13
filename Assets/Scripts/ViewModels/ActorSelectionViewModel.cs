using Models;
using UnityWeld.Binding;

namespace ViewModels {
	[Binding]
	public class ActorSelectionViewModel {
		[Binding] public string Name => _model.Id.Name;

		readonly ActorModel _model;
		
		public ActorSelectionViewModel(ActorModel model) {
			_model = model;
		}
	}
}