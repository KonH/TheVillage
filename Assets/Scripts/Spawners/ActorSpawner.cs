using UnityEngine;
using Zenject;
using World;
using Actors;

namespace Spawners {
	[RequireComponent(typeof(Area))]
	public class ActorSpawner : MonoBehaviour {
		Area          _area;
		Actor.Factory _factory;

		[Inject]
		public void Init(Actor.Factory factory) {
			_area    = GetComponent<Area>();
			_factory = factory;
		}

		public void Spawn() {
			var instance = _factory.Create();
			var position = _area.GetRandomPointOnPlane();
			instance.transform.position = position;
		}
	}
}