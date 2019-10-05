using UnityEngine;

public class MapGeneration : MonoBehaviour {

	public GameObject[] Biomes;

	private void Start() {
		int randBiome = Random.Range(10, 20);
		for (int i = 0; i <= randBiome; i++) {
			int biomeImg = Random.Range(0, Biomes.Length);
			int randX = Random.Range(-20, 20);
			int randZ = Random.Range(-20, 20);
			Vector3 newPos = new Vector3(transform.position.x + (randX * 100), transform.position.y, transform.position.z + (randZ * 100));
			Instantiate(Biomes[biomeImg], newPos, Quaternion.identity);
		}
	}
}