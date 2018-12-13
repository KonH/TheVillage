using UnityWeld.Binding;
using Models;

namespace Repositories {
	public class ActorRepository {
		public ObservableList<ActorModel> Actors { get; } = new ObservableList<ActorModel>();

		ActorSettings _settings;

		ActorIdReposilory _idRepo;

		public ActorRepository(ActorSettings settings, ActorIdReposilory idRepo) {
			_settings = settings;
			_idRepo   = idRepo;
		}

		public ActorModel Create() {
			var actor = new ActorModel(_idRepo.Create(), _settings);
			Actors.Add(actor);
			return actor;
		}

		public ActorModel TryGetAt(int index) {
			return ( (index >= 0) && (index < Actors.Count) ) ? Actors[index] : null;
		}
	}
}