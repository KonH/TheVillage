using System.Collections;
using System.Collections.Generic;
using Sources;
using UDBase.Helpers;
using UnityEngine;
using World;
using Zenject;

namespace Spawners {
	[RequireComponent(typeof(Area))]
	public class FoodSourceSpawner : MonoBehaviour {
		public FloatRange Interval;
		public float MaxInstances;
		
		Area _area;
		FoodSource.Factory _factory;

		Coroutine _routine;
		HashSet<FoodSource> _instances = new HashSet<FoodSource>();
		
		[Inject]
		public void Init(FoodSource.Factory factory) {
			_area = GetComponent<Area>();
			_factory = factory;
		}

		void OnEnable() {
			_routine = StartCoroutine(SpawnRoutine());
		}

		void OnDisable() {
			StopCoroutine(_routine);
		}

		IEnumerator SpawnRoutine() {
			while ( true ) {
				var curInterval = Interval.Random();
				yield return new WaitForSeconds(curInterval);
				if ( CanSpawn() ) {
					Spawn();
				}
			}
		}

		bool CanSpawn() {
			_instances.RemoveWhere(s => !s); // Check deleted instances
			return _instances.Count < MaxInstances;
		}

		void Spawn() {
			var instance = _factory.Create();
			var position = _area.GetRandomPointOnPlane();
			instance.transform.position = position;
			_instances.Add(instance);
		}
	}
}