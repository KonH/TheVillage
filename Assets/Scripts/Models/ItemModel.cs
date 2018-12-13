namespace Models {
	public abstract class ItemModel {
		public string Name { get; }

		protected ItemModel(string name) {
			Name = name;
		}

		public virtual void UseBy(ActorModel actor) {}
	}
}