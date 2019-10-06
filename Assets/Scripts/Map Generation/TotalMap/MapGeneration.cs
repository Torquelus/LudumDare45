using UnityEngine;

public class MapGeneration : MonoBehaviour {

	[Header("All Biomes")]
	public GameObject[] Biomes;

	[Header("Grass")]
	public GameObject grassImg;

	[Header("Number of Grass")]
	public int[] grassRange;

	[Header("Number of Biomes")]
	public int minBiomeRange = 50;
    public int maxBiomeRange = 70;

		[Header("Spawn Area (Width, Length)")]
		public int spawnAreaWidth = 500;
		public int spawnAreaLength = 500;

		private void Start() {

	[Header("Spawn Area (Width, Length)")]
	public int[] spawnArea;

	private void Start() {
		DrawBiomes();
		DrawGrass();
	}

	void DrawBiomes() {
		// Choose Number of Biomes
		int randBiome = Random.Range(minBiomeRange, maxBiomeRange);

		// Draw Biomes
		for (int i = 0; i <= randBiome; i++) {

			// Choose Biomes from list (e.g. Forest Biome, Mixed Biome, etc)
			int biomeImg = Random.Range(0, Biomes.Length);

			// Randomly Choose Point in spawn area
			int randX = Random.Range(-spawnAreaWidth, spawnAreaWidth);
			int randZ = Random.Range(-spawnAreaLength, spawnAreaLength);

			// Create the Position of new object
			Vector3 newPos = new Vector3(randX, 100, randZ);

			// Find Ground - if Ground exists instantiate on ground
			RaycastHit hit;
			if (Physics.Raycast(newPos, Vector3.down, out hit)) {
				Vector3 finalPos = hit.point;
                Debug.Log(biomeImg);
				Instantiate(Biomes[biomeImg], finalPos, Quaternion.identity);
			}
		}
	}

	void DrawGrass() {
		// Choose Number of Biomes
		int randGrass = Random.Range(grassRange[0], grassRange[1]);

		// Draw Biomes
		for (int i = 0; i <= randGrass; i++) {

			// Randomly Choose Point in spawn area
			int randX = Random.Range(-spawnArea[0], spawnArea[0]);
			int randZ = Random.Range(-spawnArea[1], spawnArea[1]);

			// Create the Position of new object
			Vector3 newPos = new Vector3(randX, 100, randZ);

			// Find Ground - if Ground exists instantiate on ground
			RaycastHit hit;
			if (Physics.Raycast(newPos, Vector3.down, out hit)) {
				Vector3 finalPos = hit.point;
				Instantiate(grassImg, finalPos, Quaternion.identity);
			}
		}
	}

}
