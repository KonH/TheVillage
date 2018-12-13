using UDBase.ViewModels;
using Zenject;
using UnityWeld.Binding;
using Models;

namespace ViewModels {
	[Binding]
	public class ActorViewModel : BaseViewModel<ActorModel> {
		[Binding] public string State  => Model.State;
		[Binding] public float  Hunger => Model.Hunger;

		[Inject]
		public override void Init(ActorModel model) {
			base.Init(model);
			GetComponentInChildren<InventoryViewModel>().Init(model);
		}

		public class Factory : Factory<ActorModel, ActorViewModel> {}
	}
}