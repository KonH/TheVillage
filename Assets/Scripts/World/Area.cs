using UnityEngine;

namespace World {
	[RequireComponent(typeof(Collider))]
	public class Area : MonoBehaviour {		
		Collider _collider;
		
		void Start() {
			_collider = GetComponent<Collider>();
		}

		public Vector3 GetRandomPointInside() {
			var bounds = _collider.bounds;
			return new Vector3(
				Random.Range(bounds.min.x, bounds.max.x),
				Random.Range(bounds.min.y, bounds.max.y),
				Random.Range(bounds.min.z, bounds.max.z)
			);
		}
		
		public Vector3 GetRandomPointOnPlane() {
			var point = GetRandomPointInside();
			point.y = 0;
			return point;
		}
	}
}