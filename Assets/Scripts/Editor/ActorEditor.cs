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
			foreach ( var state in actor.States ) {
				var stateName = state.Name;
				if ( state == actor.CurrentState ) {
					stateName = "*" + stateName;
				}
				EditorGUILayout.Slider(stateName, state.Priority, 0.0f, 1.0f);
			}
		}
	}
}