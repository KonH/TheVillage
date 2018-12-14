using UnityEngine;
using Zenject;
using Repositories;

namespace Controllers {
	public class HungerController : ITickable {
		ActorRepository _actorRepo;
		
		public HungerController(ActorRepository repo) {
			_actorRepo = repo;
		}


		public void Tick() {
			foreach ( var actor in _actorRepo.Actors ) {
				actor.Hunger += actor.Behaviour.EatDesire * Time.deltaTime;
			}
		}
	}
}