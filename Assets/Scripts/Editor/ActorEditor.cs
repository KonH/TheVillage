using Actors;
using UnityEditor;

namespace EditorScripts {
	[CustomEditor(typeof(Actor))]
	public class ActorEditor : Editor {
		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			var actor = (Actor)target;
			if ( actor.States == null ) {
				return;
			}
			EditorGUILayout.LabelField("Index: " + actor.Repo.Actors.IndexOf(actor.Model));
			EditorGUILayout.LabelField("Items: " + actor.Model.Inventory.Count);
			EditorGUILayout.Slider("Compensated Hunger", actor.Model.CompensatedHunger, 0.0f, 1.0f);
			foreach ( var state in actor.States ) {
				var stateName = state.Name;
				var isCurrentState = (state == actor.CurrentState);
				if ( isCurrentState ) {
					stateName = "*" + stateName;
				}
				state.RefreshPriority();
				EditorGUILayout.Slider(stateName, state.Priority, 0.0f, 1.0f);
			}
		}
	}
}