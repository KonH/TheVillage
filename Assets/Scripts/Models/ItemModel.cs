namespace Models {
	public abstract class ItemModel {
		public string Name { get; }

		protected ItemModel(string name) {
			Name = name;
		}
	}
}