using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sources {
	public class FoodSource : MonoBehaviour {
		public class Factory : Factory<FoodSource> {
		}
	}
}