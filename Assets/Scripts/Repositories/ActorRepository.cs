using Models;

namespace Repositories {
	public class ActorRepository {
		public ActorModel State => _state;
		
		ActorModel _state;

		public ActorRepository(ActorSettings settings) {
			_state = new ActorModel(settings);
		}
	}
}