using Models;
using UnityWeld.Binding;

namespace ViewModels {
	[Binding]
	public class ItemViewModel {
		[Binding] public string Name => _model.Name;

		readonly ItemModel _model;
		
		public ItemViewModel(ItemModel model) {
			_model = model;
		}
	}
}