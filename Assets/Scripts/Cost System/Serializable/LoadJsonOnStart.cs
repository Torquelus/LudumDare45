using UnityEngine;

public class LoadJsonOnStart : MonoBehaviour {
	CostSystem findRecipe;
	SerializeJson findJson;

	// Start is called before the first frame update
	void Start() {
		findJson = FindObjectOfType<SerializeJson>();
		findRecipe = FindObjectOfType<CostSystem>();
		Load();
	}

	// Load all Cards and spells when game starts
	void Load() {
		findJson.InitJson();
		findRecipe.InitRecipes();
	}
}
