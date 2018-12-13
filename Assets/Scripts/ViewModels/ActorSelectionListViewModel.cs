using Models;
using Repositories;
using Spawners;
using UDBase.ViewModels;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

namespace ViewModels {
	[Binding]
	public class ActorSelectionListViewModel : BaseListViewModel<ActorModel, ActorSelectionViewModel> {
		public RectTransform SelectionRoot;
		
		ActorViewModel.Factory _factory;
		ActorSpawner _spawner;
		
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
			
			var trans = viewModel.GetComponent<RectTransform>();
			trans.SetParent(SelectionRoot);
			trans.localScale = Vector3.one;
			trans.anchoredPosition = Vector2.zero;
			trans.sizeDelta = Vector2.zero;
			
			_lastSelection = viewModel;
		}

		[Binding]
		public void Spawn() {
			_spawner.Spawn();
		}
	}
}