using System;
using System.Collections.Generic;

namespace World {
	[Serializable]
	public class AreaSettings {
		[Serializable]
		public class ByTypeSettings {
			public AreaType Type;
			public float    StressChange;
		}

		public List<ByTypeSettings> Settings = new List<ByTypeSettings>();
	}
}