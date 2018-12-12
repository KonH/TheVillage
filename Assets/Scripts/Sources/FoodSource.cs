using Holders;
using Models;
using Repositories;
using UnityEngine;
using Zenject;

namespace Sources {
	public class FoodSource : MonoBehaviour {
		public FoodItemModel Model { get; private set; }
		FoodSourceHolder _holder;
		
		[Inject]
		public void Init(FoodSourceHolder holder, FoodRepository repo) {
			_holder = holder;
			Model = repo.Create();
		}

		void OnEnable() => _holder.Register(this);
		void OnDisable() => _holder.Unregister(this);

		public class Factory : Factory<FoodSourceHolder, FoodSource> {}
	}
}