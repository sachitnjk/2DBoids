using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositeBehaviour))]

public class CompositeBehaviourEditor : Editor
{
	public override void OnInspectorGUI()
	{
		//setup
		CompositeBehaviour cb = (CompositeBehaviour)target;

		if (cb.behaviours == null || cb.behaviours.Length == 0)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.HelpBox("No behaviours in array.", MessageType.Warning);
			EditorGUILayout.EndHorizontal();
		}
		else
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Behaviours", GUILayout.MinWidth(60f), GUILayout.MaxWidth(290f));
			EditorGUILayout.LabelField("Weights", GUILayout.MinWidth(65f), GUILayout.MaxWidth(65f));
			EditorGUILayout.EndHorizontal();
			EditorGUI.BeginChangeCheck();

			for (int i = 0; i < cb.behaviours.Length; i++)
			{
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(i.ToString(), GUILayout.MinWidth(20f), GUILayout.MaxWidth(20f));
				cb.behaviours[i] = (FlockBehaviour)EditorGUILayout.ObjectField(cb.behaviours[i], typeof(FlockBehaviour), false, GUILayout.MinWidth(20f));
				cb.weights[i] = EditorGUILayout.FloatField(cb.weights[i], GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
				EditorGUILayout.EndHorizontal();
			}
			if (EditorGUI.EndChangeCheck())
			{
				//Undo.RecordObject(target, "Behaviours");
				EditorUtility.SetDirty(target);
				GUIUtility.ExitGUI();
			}
		}

		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Add Behaviour"))
		{
			AddBehaviour(cb);
			GUIUtility.ExitGUI();
		}

		// Uncomment for button layout to be stacked

		/*EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();*/

		if (cb.behaviours != null && cb.behaviours.Length > 0)
		{
			if (GUILayout.Button("Remove Behaviour"))
			{
				RemoveBehaviour(cb);
				GUIUtility.ExitGUI();
			}
		}
		EditorGUILayout.EndHorizontal();
	}

	void AddBehaviour(CompositeBehaviour cb)
	{
		int oldCount = (cb.behaviours != null) ? cb.behaviours.Length : 0;
		FlockBehaviour[] newBehaviours = new FlockBehaviour[oldCount + 1];
		float[] newWeights = new float[oldCount + 1];

		for (int i = 0; i < oldCount; i++)
		{
			newBehaviours[i] = cb.behaviours[i];
			newWeights[i] = cb.weights[i];
		}
		newWeights[oldCount] = 1f;
		cb.behaviours = newBehaviours;
		cb.weights = newWeights;
	}

	void RemoveBehaviour(CompositeBehaviour cb)
	{
		int oldCount = cb.behaviours.Length;
		if (oldCount == 1)
		{
			cb.behaviours = null;
			cb.weights = null;
			return;
		}

		FlockBehaviour[] newBehaviours = new FlockBehaviour[oldCount - 1];
		float[] newWeights = new float[oldCount - 1];

		for (int i = 0; i < oldCount - 1; i++)
		{
			newBehaviours[i] = cb.behaviours[i];
			newWeights[i] = cb.weights[i];
		}
		cb.behaviours = newBehaviours;
		cb.weights = newWeights;
	}
}
