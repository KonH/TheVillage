namespace Models {
	public class FoodItemModel : ItemModel {
		public float Restore { get; }

		public FoodItemModel(float restore) : base("Food", 10) {
			Restore = restore;
		}

		public override void UseBy(ActorModel actor) {
			actor.Hunger -= Restore;
		}
	}
}