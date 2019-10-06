using UnityEngine;

public class MapGeneration : MonoBehaviour {

	public GameObject[] Biomes;

	private void Start() {
		int randBiome = Random.Range(10, 20);
		for (int i = 0; i <= randBiome; i++) {
			int biomeImg = Random.Range(0, Biomes.Length);
			int randX = Random.Range(-500, 500);
			int randZ = Random.Range(-500, 500);
			Vector3 newPos = new Vector3(randX, 100, randZ);
			RaycastHit hit;
			if (Physics.Raycast(newPos, Vector3.down, out hit)) {
				Vector3 finalPos = hit.point;
				Instantiate(Biomes[biomeImg], finalPos, Quaternion.identity);
			}
		}
	}

}