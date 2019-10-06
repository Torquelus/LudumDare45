using UnityEngine;

public class MixedSpawn : MonoBehaviour
{
	[Header("Objects In Mixed Biome")]
	public GameObject[] Mixed;

	[Header("Number of Biome Objects")]
    public int minObjects = 100;
    public int maxObjects = 200;

    [Header("Biome Range X(min, max) Z(min, max)")]
    public int minBiomeRangeX = 10;
    public int maxBiomeRangeX = 20;
    public int minBiomeRangeZ = 10;
    public int maxBiomeRangeZ = 20;

    [Header("Max Object Scale")]
	public int maxScale;

	// Start is called before the first frame update
	void Start() {

		// Number of objects in mixed Biome
		int randMixed = Random.Range(minObjects, maxObjects);

		// Random size of Biome from spawn point
		int randWid = Random.Range(minBiomeRangeX, maxBiomeRangeX);
		int randLen = Random.Range(minBiomeRangeZ, maxBiomeRangeZ);

		// Draw All Images
		for (int i = 0; i <= randMixed; i++) {

			// Choose Model to put into scene (e.g. Tree, twig)
			int mixedImg = Random.Range(0, Mixed.Length);

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
				GameObject a = Instantiate(Mixed[mixedImg], finalPos, randRotation);
				a.transform.localScale = randScale;
			}
		}
	}
}
