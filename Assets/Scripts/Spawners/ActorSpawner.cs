using System.Collections;
using System.Collections.Generic;
using Actors;
using Holders;
using Sources;
using UDBase.Helpers;
using UnityEngine;
using World;
using Zenject;

namespace Spawners {
	[RequireComponent(typeof(Area))]
	public class ActorSpawner : MonoBehaviour {
		Area _area;
		Actor.Factory _factory;

		Coroutine _routine;

		[Inject]
		public void Init(Actor.Factory factory) {
			_area = GetComponent<Area>();
			_factory = factory;
		}

		public void Spawn() {
			var instance = _factory.Create();
			var position = _area.GetRandomPointOnPlane();
			instance.transform.position = position;
		}
	}
}