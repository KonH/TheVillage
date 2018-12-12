using System;
using Models;
using UnityEngine;

namespace Repositories {
	public class FoodRepository {
		[Serializable]
		public class Settings {
			[Range(0, 1)] public float Restore;
		}

		readonly Settings _settings;

		public FoodRepository(Settings settings) {
			_settings = settings;
		}

		public FoodItemModel Create() {
			return new FoodItemModel(_settings.Restore);
		}
	}
}