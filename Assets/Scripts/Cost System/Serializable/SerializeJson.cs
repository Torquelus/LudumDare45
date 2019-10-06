using UnityEngine;
using System.IO;

public class SerializeJson : MonoBehaviour {
	string path;
	string jsonString;

	CostSystem saveCost;

	void Start() {
		InitJson();
	}

	public void InitJson() {
		path = "Assets/Scripts/Cost System/Serializable/BuildRecipes.json";
		jsonString = File.ReadAllText(path);
	}

	public ConvertJson GetJsonString() {
		ConvertJson loading = JsonUtility.FromJson<ConvertJson>(jsonString);
		return loading;
	}

	public void SaveToJson() {
		saveCost = FindObjectOfType<CostSystem>();
		InitJson();

		if (saveCost.RecipeList.Count != 0) {
			string jsonWrite = JsonUtility.ToJson(saveCost);
			File.WriteAllText(path, jsonWrite);
		}
		else {
			Debug.Log("One of More of the Lists are Empty");
		}

	}
}

[System.Serializable]
public class ConvertJson {
	public Recipes[] RecipeList;
	public string buildName;
	public int amtWood;
	public int amtStone;
	public int amtTwig;
	public int amtHay;
	public int amtGrass;
}
