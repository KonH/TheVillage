using System.Collections.Generic;
using Actors;
using Holders;
using UnityEngine;
using Zenject;

namespace World {
	[RequireComponent(typeof(Collider))]
	public class Area : MonoBehaviour {
		public AreaType Type;
		
		public HashSet<Actor> Visitors { get; set; } = new HashSet<Actor>();

		AreaHolder _holder;
		Collider _collider;
		
		[Inject]
		public void Init(AreaHolder holder) {
			_holder = holder;
			_collider = GetComponent<Collider>();
		}

		void OnEnable() {
			_holder.Register(this);
		}

		void OnDisable() {
			_holder.Unregister(this);
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

		void OnDrawGizmos() {
			Gizmos.color = GetGizmoColor();
			var col = GetComponent<Collider>();
			Gizmos.DrawCube(col.bounds.center, col.bounds.size);
		}

		Color GetGizmoColor() {
			switch ( Type ) {
				case AreaType.Food: return Color.green;
				case AreaType.Home: return Color.blue;
			}
			return Color.magenta;
		}
	}
}