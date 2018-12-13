using UnityEngine;
using UDBase.ViewModels;
using Zenject;
using UnityWeld.Binding;
using Models;
using Spawners;
using Repositories;

namespace ViewModels {
	[Binding]
	public class ActorSelectionListViewModel : BaseListViewModel<ActorModel, ActorSelectionViewModel> {
		public RectTransform SelectionRoot;

		ActorViewModel.Factory _factory;
		ActorSpawner           _spawner;
		
		ActorViewModel _lastSelection;
		
		[Inject]
		public void Init(ActorRepository repo, ActorViewModel.Factory factory, ActorSpawner spawner) {
			_factory = factory;
			_spawner = spawner;
			Init(repo.Actors);
		}
		
		protected override ActorSelectionViewModel CreateView(ActorModel model) {
			return new ActorSelectionViewModel(this, model);
		}

		public void OnClick(ActorModel model) {
			if ( _lastSelection != null ) {
				Destroy(_lastSelection.gameObject);
			}
			var viewModel = _factory.Create(model);
			AttachToRoot(viewModel.GetComponent<RectTransform>());
			_lastSelection = viewModel;
		}

		void AttachToRoot(RectTransform trans) {
			trans.SetParent(SelectionRoot);
			trans.localScale       = Vector3.one;
			trans.anchoredPosition = Vector2.zero;
			trans.sizeDelta        = Vector2.zero;
		}
		
		[Binding]
		public void Spawn() {
			_spawner.Spawn();
		}
	}
}