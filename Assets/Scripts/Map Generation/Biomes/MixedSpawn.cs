using UnityEngine;

public class MixedSpawn : MonoBehaviour
{
	public GameObject[] Mixed;

	// Start is called before the first frame update
	void Start() {
		int randMixed = Random.Range(5, 15);
		for (int i = 0; i <= randMixed; i++) {
			int mixedImg = Random.Range(0, Mixed.Length);
			int randX = Random.Range(-11, 11);
			int randZ = Random.Range(-11, 11);
			Vector3 newPos = new Vector3(transform.position.x + (randX * 10), transform.position.y, transform.position.z + (randZ*10));
			Instantiate(Mixed[mixedImg], newPos, Quaternion.identity);
		}
	}
}
