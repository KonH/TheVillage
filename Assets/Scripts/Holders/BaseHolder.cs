using System;
using System.Collections.Generic;
using UnityEngine;

namespace Holders {
	public class BaseHolder<TItem> : MonoBehaviour where TItem : MonoBehaviour {
		protected HashSet<TItem> Instances { get; } = new HashSet<TItem>();

		public int Count => Instances.Count;
		
		public void Register(TItem area) => Instances.Add(area);
		public void Unregister(TItem area) => Instances.Remove(area);

		public HashSet<TItem> Filter(Func<TItem, bool> func) {
			var result = new HashSet<TItem>();
			foreach ( var instance in Instances ) {
				if ( func(instance) ) {
					result.Add(instance);
				}
			}
			return result;
		}
		
		public TItem GetNearest(Vector3 pos, Func<TItem, bool> filter = null) {
			var   instances    = (filter != null) ? Filter(filter) : Instances;
			var   nearDistance = float.MaxValue;
			TItem nearInstance = null;
			foreach ( var instance in instances ) {
				var distance = Vector3.Distance(pos, instance.transform.position);
				if ( distance < nearDistance ) {
					nearDistance = distance;
					nearInstance = instance;
				}
			}
			return nearInstance;
		}
	}
}