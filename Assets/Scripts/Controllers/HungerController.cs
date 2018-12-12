using System;
using Models;
using Repositories;
using UnityEngine;
using Zenject;

namespace Controllers {
	public class HungerController : ITickable {
		[Serializable]
		public class Settings {
			[Range(0, 1)] public float Increase;
		}

		Settings _settings;

		ActorRepository _actorRepo;
		
		public HungerController(Settings settings, ActorRepository repo) {
			_settings = settings;
			_actorRepo = repo;
		}


		public void Tick() {
			foreach ( var actor in _actorRepo.Actors ) {
				actor.Hunger += _settings.Increase * Time.deltaTime;
			}
		}
	}
}