using UnityEngine;

public class ForestsSpawn : MonoBehaviour
{
	public GameObject[] Forests;

	// Start is called before the first frame update
	void Start() {
		int randForest = Random.Range(10, 20);
		for (int i = 0; i <= randForest; i++) {
			int forestImg = Random.Range(0, Forests.Length);
			int randX = Random.Range(-11, 11);
			int randZ = Random.Range(-11, 11);
			Vector3 newPos = new Vector3(transform.position.x + (randX * 10), transform.position.y, transform.position.z + (randZ * 10));
			Instantiate(Forests[forestImg], newPos, Quaternion.identity);
		}
	}
}
