using Models;
using Repositories;
using UDBase.ViewModels;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

namespace ViewModels {
	[Binding]
	public class ActorSelectionListViewModel : BaseListViewModel<ActorModel, ActorSelectionViewModel> {
		public RectTransform SelectionRoot;
		
		ActorViewModel.Factory _factory;
		ActorViewModel _lastSelection;
		
		[Inject]
		public void Init(ActorRepository repo, ActorViewModel.Factory factory) {
			_factory = factory;
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
			viewModel.Init(model);
			
			var trans = viewModel.GetComponent<RectTransform>();
			trans.SetParent(SelectionRoot);
			trans.localScale = Vector3.one;
			trans.anchoredPosition = Vector2.zero;
			trans.sizeDelta = Vector2.zero;
			
			_lastSelection = viewModel;
		}
	}
}