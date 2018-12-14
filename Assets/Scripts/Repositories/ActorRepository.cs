using UnityWeld.Binding;
using Models;

namespace Repositories {
	public class ActorRepository {
		public ObservableList<ActorModel> Actors { get; } = new ObservableList<ActorModel>();

		ActorIdReposilory           _idRepo;
		ActorBehaviourModel.Factory _behaviourFactory;

		public ActorRepository(ActorIdReposilory idRepo, ActorBehaviourModel.Factory behaviorFactory) {
			_idRepo           = idRepo;
			_behaviourFactory = behaviorFactory;
		}

		public ActorModel Create() {
			var actor = new ActorModel(_idRepo.Create(), _behaviourFactory.Create());
			Actors.Add(actor);
			return actor;
		}

		public ActorModel TryGetAt(int index) {
			return ( (index >= 0) && (index < Actors.Count) ) ? Actors[index] : null;
		}
	}
}