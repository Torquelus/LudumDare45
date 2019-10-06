using UnityEngine;

public class BoulderSpawn : MonoBehaviour
{
	[Header("Objects In Boulder Area")]
	public GameObject[] Boulder;

	[Header("Number of Biome Objects")]
	public int[] bouldRange;

	[Header("Biome Range X(min, max) Z(min, max)")]
	public int[] biomeRange;

	[Header("Max Object Scale")]
	public int maxScale;

	// Start is called before the first frame update
	void Start() {

		// Number of Trees and Twigs in forest
		int randBould = Random.Range(bouldRange[0], bouldRange[1]);

		// Random size of Biome from spawn point
		int randWid = Random.Range(biomeRange[0], biomeRange[1]);
		int randLen = Random.Range(biomeRange[2], biomeRange[3]);

		// Draw All Images
		for (int i = 0; i <= randBould; i++) {

			// Choose Model to put into scene (e.g. Boulders, Stones)
			int bouldImg = Random.Range(0, Boulder.Length);

			// Random Position in range
			int randX = Random.Range(-randWid, randWid);
			int randZ = Random.Range(-randLen, randLen);

			// Random Scale Factor
			int scaleFactor = Random.Range(1, maxScale);

			// Create the Position, Rotation and Scale of new object 
			Vector3 newPos = new Vector3(transform.position.x + (randX), 100, transform.position.z + (randZ));
			Quaternion randRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
			Vector3 randScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

			// Find Ground - if Ground exists instantiate on ground
			if (Physics.Raycast(newPos, Vector3.down, out RaycastHit hit)) {
				Vector3 finalPos = hit.point;
				GameObject a = Instantiate(Boulder[bouldImg], finalPos, randRotation);
				a.transform.localScale = randScale;
			}
		}
	}
}
