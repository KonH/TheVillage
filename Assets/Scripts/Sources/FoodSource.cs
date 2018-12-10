using Holders;
using UnityEngine;
using Zenject;

namespace Sources {
	public class FoodSource : MonoBehaviour {
		FoodSourceHolder _holder;
		
		[Inject]
		public void Init(FoodSourceHolder holder) {
			_holder = holder;
		}

		void OnEnable() => _holder.Register(this);
		void OnDisable() => _holder.Unregister(this);

		public class Factory : Factory<FoodSourceHolder, FoodSource> {}
	}
}