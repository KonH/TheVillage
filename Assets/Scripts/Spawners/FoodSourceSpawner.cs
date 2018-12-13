using System.Collections;
using UnityEngine;
using UDBase.Helpers;
using Zenject;
using World;
using Holders;
using Sources;

namespace Spawners {
	[RequireComponent(typeof(Area))]
	[RequireComponent(typeof(FoodSourceHolder))]
	public class FoodSourceSpawner : MonoBehaviour {
		public FloatRange Interval;
		public float      MaxInstances;

		Area               _area;
		FoodSourceHolder   _holder;
		FoodSource.Factory _factory;

		Coroutine _routine;

		[Inject]
		public void Init(FoodSource.Factory factory) {
			_area    = GetComponent<Area>();
			_holder  = GetComponent<FoodSourceHolder>();
			_factory = factory;
		}

		void OnEnable() {
			_routine = StartCoroutine(SpawnRoutine());
		}

		void OnDisable() {
			StopCoroutine(_routine);
		}

		IEnumerator SpawnRoutine() {
			while ( enabled ) {
				var curInterval = Interval.Random();
				yield return new WaitForSeconds(curInterval);
				if ( CanSpawn() ) {
					Spawn();
				}
			}
		}

		bool CanSpawn() {
			return _holder.Count < MaxInstances;
		}

		void Spawn() {
			var instance = _factory.Create(_holder);
			var position = _area.GetRandomPointOnPlane();
			instance.transform.position = position;
		}
	}
}