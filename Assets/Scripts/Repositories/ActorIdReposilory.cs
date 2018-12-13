using Models;

namespace Repositories {
	public class ActorIdReposilory {
		int _count = 0;
		
		public ActorId Create() {
			_count++;
			return new ActorId(_count);
		}
	}
}