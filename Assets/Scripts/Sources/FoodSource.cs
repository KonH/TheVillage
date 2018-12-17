using UnityEngine;
using Zenject;
using Models;
using Holders;
using Repositories;

namespace Sources {
	public class FoodSource : MonoBehaviour {
		public FoodItemModel Model { get; private set; }
		
		FoodSourceHolder _holder;
		
		[Inject]
		public void Init(FoodSourceHolder holder, FoodRepository repo) {
			_holder = holder;
			Model   = repo.Create();
		}

		void OnEnable() => _holder.Register(this);
		void OnDisable() => _holder.Unregister(this);

		public class Factory : PlaceholderFactory<FoodSourceHolder, FoodSource> {}
	}
}