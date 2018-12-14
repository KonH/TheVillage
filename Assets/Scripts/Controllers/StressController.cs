using Holders;
using UnityEngine;
using Zenject;
using Repositories;
using World;

namespace Controllers {
	public class StressController : ITickable {
		ActorRepository _actorRepo;
		AreaHolder      _areas;
		
		public StressController(ActorRepository repo, AreaHolder areas) {
			_actorRepo = repo;
			_areas     = areas;
		}


		public void Tick() {
			foreach ( var actor in _actorRepo.Actors ) {
				var inHome    = (_areas.GetAreaInside(actor.Id, AreaType.Home) != null);
				var behaviour = actor.Behaviour;
				var value     = inHome ? -behaviour.StressRestore : behaviour.StressIncrease;
				actor.Stress += value * Time.deltaTime;
			}
		}
	}
}