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
		ActorModel _model;
		
		public HungerController(Settings settings, ActorRepository repo) {
			_settings = settings;
			_model = repo.State;
		}


		public void Tick() {
			_model.Hunger += _settings.Increase * Time.deltaTime;
		}
	}
}