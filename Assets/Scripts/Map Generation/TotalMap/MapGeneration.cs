using UnityEngine;

public class MapGeneration : MonoBehaviour {

	[Header("All Biomes")]
	public GameObject[] Biomes;

	[Header("Number of Biomes")]
	public int[] biomeRange;

	[Header("Spawn Area (Width, Length)")]
	public int[] spawnArea;
	
	private void Start() {

		// Choose Number of Biomes
		int randBiome = Random.Range(biomeRange[0], biomeRange[1]);

		// Draw Biomes
		for (int i = 0; i <= randBiome; i++) {

			// Choose Biomes from list (e.g. Forest Biome, Mixed Biome, etc)
			int biomeImg = Random.Range(0, Biomes.Length);

			// Randomly Choose Point in spawn area
			int randX = Random.Range(-spawnArea[0], spawnArea[0]);
			int randZ = Random.Range(-spawnArea[1], spawnArea[1]);

			// Create the Position of new object 
			Vector3 newPos = new Vector3(randX, 100, randZ);

			// Find Ground - if Ground exists instantiate on ground
			RaycastHit hit;
			if (Physics.Raycast(newPos, Vector3.down, out hit)) {
				Vector3 finalPos = hit.point;
				Instantiate(Biomes[biomeImg], finalPos, Quaternion.identity);
			}
		}
	}

}