using Models;
using Repositories;
using UDBase.ViewModels;
using UnityWeld.Binding;
using Zenject;

namespace ViewModels {
	[Binding]
	public class InventoryViewModel : BaseListViewModel<ItemModel, ItemViewModel> {
		public void Init(ActorModel model) {
			base.Init(model.Inventory);
		}
		
		protected override ItemViewModel CreateView(ItemModel model) {
			return new ItemViewModel(model);
		}
	}
}