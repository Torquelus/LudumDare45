using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeadowSpawn : MonoBehaviour
{
	public GameObject[] Meadow;

	// Start is called before the first frame update
	void Start() {
		int randMeadow = Random.Range(5, 15);
		for (int i = 0; i <= randMeadow; i++) {
			int meadowImg = Random.Range(0, Meadow.Length);
			int randX = Random.Range(-11, 11);
			int randZ = Random.Range(-11, 11);
			Vector3 newPos = new Vector3(transform.position.x + (randX * 10), transform.position.y, transform.position.z + (randZ * 10));
			Instantiate(Meadow[meadowImg], newPos, Quaternion.identity);
		}
	}
}
