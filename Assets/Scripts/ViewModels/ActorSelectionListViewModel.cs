using Models;
using Repositories;
using UDBase.ViewModels;
using UnityWeld.Binding;
using Zenject;

namespace ViewModels {
	[Binding]
	public class ActorSelectionListViewModel : BaseListViewModel<ActorModel, ActorSelectionViewModel> {
		[Inject]
		public void Init(ActorRepository repo) {
			Init(repo.Actors);
		}
		
		protected override ActorSelectionViewModel CreateView(ActorModel model) {
			return new ActorSelectionViewModel(model);
		}
	}
}