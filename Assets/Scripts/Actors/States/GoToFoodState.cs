using UnityEngine;
using World;

namespace Actors.States {	
	public class GoToFoodState : ActorState {
		Area _foodArea;
		
		public GoToFoodState(Actor owner) : base(owner) { }
		
		public override float UpdatePriority() {
			_foodArea = Owner.Areas.GetNearestAreaWithType(AreaType.Food, Owner.transform.position);
			return ( (_foodArea != null) && !Owner.IsInside(_foodArea) ) ? 1.0f : 0.0f;
		}

		public override void OnEnter() {
			Owner.Agent.destination = _foodArea.transform.position;
		}

		public override void OnExit() {
			Owner.Agent.ResetPath();
		}

		public override bool Update() {
			return Owner.IsInside(_foodArea);
		}
	}
}