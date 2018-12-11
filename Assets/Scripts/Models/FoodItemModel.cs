namespace Models {
	public class FoodItemModel : ItemModel {
		public FoodItemModel():base("Food") { }

		public override void UseBy(ActorModel actor) {
			actor.Hunger -= 1.0f;
		}
	}
}