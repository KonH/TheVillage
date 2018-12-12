using System.Collections.Generic;
using Models;

namespace Repositories {
	public class ActorRepository {
		public List<ActorModel> Actors { get; } = new List<ActorModel>();

		ActorSettings _settings;

		public ActorRepository(ActorSettings settings) {
			_settings = settings;
		}

		public ActorModel Create() {
			var actor = new ActorModel(_settings);
			Actors.Add(actor);
			return actor;
		}

		public ActorModel TryGetAt(int index) {
			return ( (index >= 0) && (index < Actors.Count) ) ? Actors[index] : null;
		}
	}
}