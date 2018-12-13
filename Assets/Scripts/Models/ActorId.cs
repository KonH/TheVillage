namespace Models {
	public struct ActorId {
		public int Index { get; }
		public string Name { get; }

		public ActorId(int index) {
			Index = index;
			Name = "Actor_" + Index;
		}
	}
}