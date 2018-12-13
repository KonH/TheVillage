using UnityWeld.Binding;
using UDBase.ViewModels;
using Models;

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