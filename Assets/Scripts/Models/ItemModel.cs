namespace Models {
	public abstract class ItemModel {
		public string Name  { get; }
		public int    Price { get; }

		protected ItemModel(string name, int price) {
			Name  = name;
			Price = price;
		}

		public virtual void UseBy(ActorModel actor) {}
	}
}