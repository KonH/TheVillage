using Models;
using Repositories;
using UDBase.ViewModels;
using UnityWeld.Binding;
using Zenject;

namespace ViewModels {
	[Binding]
	public class ActorViewModel : BaseViewModel<ActorModel> {
		[Binding] public string State => Model.State;
		[Binding] public float Hunger => Model.Hunger;

		[Inject]
		public void Init(ActorRepository repo) {
			//base.Init(repo.Actors[0]); // temp
		}
	}
}