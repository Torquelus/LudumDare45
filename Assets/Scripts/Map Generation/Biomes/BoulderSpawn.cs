using UnityEngine;

public class BoulderSpawn : MonoBehaviour
{
	public GameObject[] Boulders;
	// Start is called before the first frame update
	void Start() {
		int randBould = Random.Range(5, 15);
		for (int i = 0; i <= randBould; i++) {
			int bouldImg = Random.Range(0, Boulders.Length);
			int randX = Random.Range(-11, 11);
			int randZ = Random.Range(-11, 11);
			
			Vector3 newPos = new Vector3(transform.position.x + (randX * 10), 100, transform.position.z + (randZ * 10));

			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.down, out hit)){
				Vector3 finalPos = hit.point;
				Instantiate(Boulders[bouldImg], finalPos, Quaternion.identity);
			}

		}
	}
}
