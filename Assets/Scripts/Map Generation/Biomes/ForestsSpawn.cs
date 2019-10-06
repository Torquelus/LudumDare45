using UnityEngine;

public class ForestsSpawn : MonoBehaviour
{
	[Header("Objects In Forests")]
	public GameObject[] Forests;
    Transform parent;

    [Header("Number of Biome Objects")]
	public int minObjects = 100;
    public int maxObjects = 200;

    [Header("Biome Range X(min, max) Z(min, max)")]
    public int minBiomeRangeX = 1;
    public int maxBiomeRangeX = 9;
    public int minBiomeRangeZ = 1;
    public int maxBiomeRangeZ = 9;

    [Header("Max Object Scale")]
	public int maxScale = 3;

	[Header("Radius Range")]
	public int radiusX = 1;
	public int radiusZ = 9;

	[Header("Radius Changer")]
	public int randXMult = 4;
	public int randZMult = 6;

	// Start is called before the first frame update
	void Start() {
        // Initialise parent
        parent = GameObject.Find("WorldObjects").transform;

        // Number of Trees and Twigs in forest
        int randForest = Random.Range(minObjects, maxObjects);

		// Random size of Biome from spawn pointngeX);
		int multiplier = Random.Range(1, 9); ;

		// Draw All Images
		for (int i = 0; i <= randForest; i++) {

			// Choose Model to put into scene (e.g. Tree, twig)
			int forestImg = Random.Range(0, Forests.Length);

			// Random Position in Circle
			Vector2 inCircle = new Vector2();
			inCircle = Random.insideUnitCircle*multiplier;

			// Random Scale Factor
			int scaleFactor = Random.Range(1, maxScale);

			// Create the Position, Rotation and Scale of new object 
			Vector3 newPos = new Vector3((transform.position.x + inCircle[0]*randXMult), 100, (transform.position.z + inCircle[1]*randZMult));
			Quaternion randRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
			Vector3 randScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

			// Find Ground - if Ground exists instantiate on ground
			if (Physics.Raycast(newPos, Vector3.down, out RaycastHit hit) && hit.transform.tag == "Ground") {
				Vector3 finalPos = hit.point;
				GameObject a = Instantiate(Forests[forestImg], finalPos, randRotation, parent);
				a.transform.localScale = randScale;
			}
		}
	}
}
