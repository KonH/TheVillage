using UnityEditor;
using Holders;

namespace EditorScripts {
	[CustomEditor(typeof(ItemHolder))]
	public class ItemHolderEditor : Editor {
		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			var holder = (ItemHolder)target;
			EditorGUILayout.LabelField("Items: " + holder.Items.Count);
			foreach ( var item in holder.Items ) {
				EditorGUILayout.LabelField(item.Name);
			}
		}
	}
}