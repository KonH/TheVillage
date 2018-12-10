using System.Collections.Generic;
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
	}
}