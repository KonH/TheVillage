using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Actors;
using Holders;

namespace World {
	[RequireComponent(typeof(Collider))]
	public class Area : MonoBehaviour {
		public AreaType Type;
		
		public HashSet<Actor> Visitors { get; set; } = new HashSet<Actor>();

		public float StressChange {
			get {
				foreach ( var setting in _settings.Settings ) {
					if ( Type == setting.Type ) {
						return setting.StressChange;
					}
				}
				return 0.0f;
			}
		}

		AreaSettings _settings;
		AreaHolder   _holder;
		Collider     _collider;
		
		[Inject]
		public void Init(AreaSettings settings, AreaHolder holder) {
			_settings = settings;
			_holder   = holder;
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
			var color = GetGizmoColor();
			color.a = 0.5f;
			Gizmos.color = color;
			var col = GetComponent<Collider>();
			Gizmos.DrawCube(col.bounds.center, col.bounds.size);
		}

		Color GetGizmoColor() {
			switch ( Type ) {
				case AreaType.Food: return Color.green;
				case AreaType.Home: return Color.blue;
				case AreaType.Shop: return Color.yellow;
				case AreaType.Bar : return Color.cyan;
			}
			return Color.magenta;
		}
	}
}