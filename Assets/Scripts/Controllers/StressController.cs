using Holders;
using UnityEngine;
using Zenject;
using Repositories;
using World;

namespace Controllers {
	public class StressController : ITickable {
		ActorRepository _actorRepo;
		AreaHolder      _areaHolder;
		
		public StressController(ActorRepository repo, AreaHolder areaHolder) {
			_actorRepo  = repo;
			_areaHolder = areaHolder;
		}


		public void Tick() {
			foreach ( var actor in _actorRepo.Actors ) {
				var areas = _areaHolder.GetAreasInside(actor.Id);
				foreach ( var area in areas ) {
					var change    = area.StressChange;
					var behaviour = actor.Behaviour;
					var baseValue = (change > 0) ? behaviour.StressRestore : behaviour.StressIncrease;
					var value     = baseValue * change;
					actor.Stress += value * Time.deltaTime;
				}
			}
		}
	}
}