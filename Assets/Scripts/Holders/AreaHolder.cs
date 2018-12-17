using System.Collections.Generic;
using Actors;
using Models;
using UnityEngine;
using World;

namespace Holders {
	public class AreaHolder : BaseHolder<Area> {
		public HashSet<Area> Filter(AreaType type) {
			return Filter(a => a.Type == type);
		}

		public Area GetNearestAreaWithType(AreaType type, Vector3 pos) {
			return GetNearest(pos, a => a.Type == type);
		}

		public Area GetAreaInside(Actor actor, AreaType type) {
			foreach ( var area in Filter(type) ) {
				if ( area.Visitors.Contains(actor) ) {
					return area;
				}
			}
			return null;
		}
		
		public Area GetAreaInside(ActorId id, AreaType type) {
			foreach ( var area in Filter(type) ) {
				foreach ( var visitor in area.Visitors ) {
					if ( visitor.Model.Id.Index == id.Index ) {
						return area;
					}
				}
			}
			return null;
		}
		
		public List<Area> GetAreasInside(ActorId id) {
			var result = new List<Area>();
			foreach ( var area in Instances ) {
				foreach ( var visitor in area.Visitors ) {
					if ( visitor.Model.Id.Index == id.Index ) {
						result.Add(area);
					}
				}
			}
			return result;
		}
	}
}