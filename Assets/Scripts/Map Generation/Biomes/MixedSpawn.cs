using UnityEngine;

public class MixedSpawn : MonoBehaviour
{
	[Header("Objects In Mixed Biome")]
	public GameObject[] Mixed;

	[Header("Number of Biome Objects")]
	public int[] mixedRange;

	[Header("Biome Range X(min, max) Z(min, max)")]
	public int[] biomeRange;

	// Start is called before the first frame update
	void Start() {

		// Number of objects in mixed Biome
		int randMixed = Random.Range(mixedRange[0], mixedRange[1]);

		// Random size of Biome from spawn point
		int randWid = Random.Range(biomeRange[0], biomeRange[1]);
		int randLen = Random.Range(biomeRange[2], biomeRange[3]);

		// Draw All Images
		for (int i = 0; i <= randMixed; i++) {

			// Choose Model to put into scene (e.g. Tree, twig)
			int mixedImg = Random.Range(0, Mixed.Length);

			// Random Position in range
			int randX = Random.Range(-randWid, randWid);
			int randZ = Random.Range(-randLen, randLen);

			// Create the Position of new object 
			Vector3 newPos = new Vector3(transform.position.x + (randX), 100, transform.position.z + (randZ));

			// Find Ground - if Ground exists instantiate on ground
			RaycastHit hit;
			if (Physics.Raycast(newPos, Vector3.down, out hit)) {
				Vector3 finalPos = hit.point;
				Instantiate(Mixed[mixedImg], finalPos, Quaternion.identity);
			}
		}
	}
}
