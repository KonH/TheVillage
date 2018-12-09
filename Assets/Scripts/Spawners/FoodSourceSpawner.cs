using Sources;
using UnityEngine;
using Zenject;

namespace Spawners {
	public class FoodSourceSpawner : MonoBehaviour {
		FoodSource.Factory _factory;

		[Inject]
		public void Init(FoodSource.Factory factory) {
			_factory = factory;
		}

		void Start() {
			var instance = _factory.Create();
			Debug.Log(instance);
		}
	}
}