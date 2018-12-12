using Models;
using Repositories;
using UDBase.ViewModels;
using UnityWeld.Binding;
using Zenject;

namespace ViewModels {
	[Binding]
	public class InventoryViewModel : BaseListViewModel<ItemModel, ItemViewModel> {
		[Inject]
		public void Init(ActorRepository repo) {
			Init(repo.Actors[0].Inventory); // temp
		}

		protected override ItemViewModel CreateView(ItemModel model) {
			return new ItemViewModel(model);
		}
	}
}