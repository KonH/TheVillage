using Models;

namespace Repositories {
	public class ActorRepository {
		public ActorModel State => _state;
		
		ActorModel _state = new ActorModel();
	}
}