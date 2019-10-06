using UnityEngine;
using UnityEditor;

public class Editor : EditorWindow {
	CostSystem findRecipe;
	SerializeJson findJson;


	[MenuItem("Window/Data Storage")]
	public static void ShowWindow() {

		GetWindow<Editor>("Save and Load");
	}

	void OnGUI() {
		findJson = FindObjectOfType<SerializeJson>();
		findRecipe = FindObjectOfType<CostSystem>();

		// Window Code
		GUILayout.Label("Load Json Files", EditorStyles.boldLabel);
		if (GUILayout.Button("Load")) {
			findJson.InitJson();
			findRecipe.InitRecipes();
		}

		GUILayout.Label("Save Json Files", EditorStyles.boldLabel);
		if (GUILayout.Button("Save")) {
			findJson.SaveToJson();
		}

	}
}
