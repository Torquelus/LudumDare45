using UnityEngine;

public class MapGeneration : MonoBehaviour {

	public GameObject[] Biomes;

	private void Start() {
		int randBiome = Random.Range(10, 20);
		for (int i = 0; i <= randBiome; i++) {
			int biomeImg = Random.Range(0, Biomes.Length);
			int randX = Random.Range(-20, 20);
			int randZ = Random.Range(-20, 20);
			Vector3 newPos = new Vector3(transform.position.x + (randX * 20), 100, transform.position.z + (randZ * 20));
			RaycastHit hit;
			Debug.Log(Physics.Raycast(newPos, Vector3.down, out hit));
			Instantiate(Biomes[biomeImg], newPos, Quaternion.identity);
			RaycastHit hit2;
			Debug.Log(Physics.Raycast(newPos, Vector3.down, out hit2));
		}
	}
}