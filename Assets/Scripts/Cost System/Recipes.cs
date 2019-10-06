using UnityEngine;

[System.Serializable]
public class Recipes
{

	[Header("Recipe Name")]
	public string recipeName;

	[Header("Amount Recources")]
	public int amtWood;
	public int amtStone;
	public int amtTwig;
	public int amtHay;
	public int amtGrass;

}
