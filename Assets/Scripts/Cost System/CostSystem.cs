using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CostSystem : MonoBehaviour {

	public List<Recipes> RecipeList = new List<Recipes>();

	SerializeJson useJson;

	void Start() {
		InitRecipes();
	}

	public void InitRecipes() {
		PopulateRecipes();
	}

	void PopulateRecipes() {
		useJson = FindObjectOfType<SerializeJson>();
		ConvertJson load = useJson.GetJsonString();
		RecipeList.Clear();
		foreach (Recipes a in load.RecipeList) {
			RecipeList.Add(a);
		}
	}
}
