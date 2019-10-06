using UnityEngine;

public class GlobalResources : MonoBehaviour{
	
	// Holds all the resources
	[HideInInspector]
	public WoodData wood;

	[HideInInspector]
	public StoneData stone;

	[HideInInspector]
	public PopulationData pop;

	[HideInInspector]
	public TwigData twig;

	[HideInInspector]
	public GrassData grass;

	[HideInInspector]
	public HayData hay;

	// Add Amount to resource
	public void AddAmt(string resource, int amt) {
		switch (resource){
			case "Wood":
				wood.amtWood += amt;
				break;

			case "Stone":
				stone.amtStone+= amt;
				break;

			case "Pop":
				pop.amtPop += amt;
				break;

			case "Twig":
				twig.amtTwig += amt;
				break;

			case "Grass":
				grass.amtGrass += amt;
				break;

			case "Hay":
				hay.amtHay += amt;
				break;
		}
	}

	// Check if there is enough resource
	public bool CheckAmt(string resource, int amt) {

		bool available = false; 
		switch (resource) {
			case "Wood":
				if (wood.amtWood >= amt) {
					available = true;
				}
				break;

			case "Stone":
				if (stone.amtStone >= amt) {
					available = true;
				}
				break;

			case "Pop":
				if (pop.amtPop >= amt) {
					available = true;
				}
				break;

			case "Grass":
				if (grass.amtGrass >= amt) {
					available = true;
				}
				break;

			case "Twig":
				if (twig.amtTwig >= amt) {
					available = true;
				}
				break;

			case "Hay":
				if (hay.amtHay >= amt) {
					available = true;
				}
				break;
		}

		return available;
	}

	// Use the resource
	public void UseAmt(string resource, int amt) {
		switch (resource) {
			case "Wood":
				wood.amtWood -= amt;
				break;

			case "Stone":
				stone.amtStone -= amt;
				break;

			case "Pop":
				pop.amtPop -= amt;
				break;

			case "Twig":
				twig.amtTwig -= amt;
				break;

			case "Grass":
				grass.amtGrass -= amt;
				break;

			case "Hay":
				hay.amtHay-= amt;
				break;
		}
	}
}
