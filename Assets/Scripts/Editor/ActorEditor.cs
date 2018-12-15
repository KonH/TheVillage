using UnityEditor;
using Actors;

namespace EditorScripts {
	[CustomEditor(typeof(Actor))]
	public class ActorEditor : Editor {
		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			var actor = (Actor)target;
			if ( actor.States == null ) {
				return;
			}
			var model = actor.Model;
			EditorGUILayout.LabelField("Name: " + model.Id.Name);
			EditorGUILayout.LabelField("Items: " + model.Inventory.Count);
			EditorGUILayout.Slider("FoodRestore", model.NormalizedFoodRestore, 0.0f, 1.0f);
			EditorGUILayout.Slider("Hunger", model.Hunger, 0.0f, 1.0f);
			EditorGUILayout.Slider("Stress", model.Stress, 0.0f, 1.0f);
			EditorGUILayout.Separator();
			
			var behavior = model.Behaviour;
			EditorGUILayout.LabelField("Greedy: " + behavior.Greedy);
			EditorGUILayout.Slider("EatDesire", behavior.EatDesire, 0.0f, 1.0f);
			EditorGUILayout.Slider("OwnedFoodSatisfaction", behavior.OwnedFoodSatisfaction, 0.0f, 1.0f);
			EditorGUILayout.Separator();
			
			foreach ( var state in actor.States ) {
				var stateName = state.Name;
				var isCurrentState = (state == actor.CurrentState);
				if ( isCurrentState ) {
					stateName = "*" + stateName;
				}
				state.RefreshPriority();
				EditorGUILayout.Slider(stateName, state.Priority, -1.0f, 1.0f);
			}
		}
	}
}