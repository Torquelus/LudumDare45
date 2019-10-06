using UnityEngine;

// Must Have Mesh
[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
	// This Mesh
	Mesh mesh;

	// Vertices and triangles that make up mesh
	Vector3[] vertices;
	int[] triangles;

	[Header("Length and Width of Terrain")]
	public int xSize = 10;
	public int zSize = 10;

	[Header("Multipler - Polygon Changer")]
	public int multiplier = 100;

	[Header("Change Noise Range")]
	public float minNoiseX = 0.3f;
	public float maxNoiseX = 1.0f;
	public float minNoiseY = 0.5f;
	public float maxNoiseY = 1.5f;
	public float maxNoiseZ = 0.3f;
	public float minNoiseZ = 1.0f;

	// Start is called before the first frame update
	void Awake()
    {
		// Declare as mesh and instantiate Mesh Filter
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		// Create and Draw Mesh
		CreateShape();
		UpdateMesh();

		// Add Collider
		GetComponent<MeshCollider>().sharedMesh = mesh;
	}

	// Create the Mesh
	void CreateShape() {

		// Create Vector equaling size of Mesh
		vertices = new Vector3[(xSize + 1) * (zSize + 1)];

		float noiseY = Random.Range(minNoiseY,maxNoiseY);
		float noiseX = Random.Range(minNoiseX, maxNoiseX);
		float noiseZ = Random.Range(minNoiseZ, maxNoiseZ);

		// Loop through and instantiate all vertices
		for (int i = 0, z = -zSize/2; z <= zSize/2; z++) {
			for (int x = -xSize/2; x <= xSize/2; x++) {
				float y = Mathf.PerlinNoise(x * noiseX, z * noiseZ) * noiseY;
				vertices[i] = new Vector3(x * multiplier, y * multiplier, z * multiplier);
				i++;
			}
		}

		// Create Triangles equaling size of Mesh
		triangles = new int[xSize * zSize * 6];

		// Loop through and instantiate all triangles
		for (int vert = 0, tries = 0,  z = -zSize/2; z < zSize/2; z++) { 
			for (int x = -xSize/2; x < xSize/2; x++) {
				triangles[0 + tries] = vert + 0;
				triangles[1 + tries] = vert + xSize + 1;
				triangles[2 + tries] = vert + 1;
				triangles[3 + tries] = vert + 1;
				triangles[4 + tries] = vert + xSize + 1;
				triangles[5 + tries] = vert + xSize + 2;
				vert++;
				tries += 6;
			}
			vert++;
		}
	}

	// Draw the Mesh
	void UpdateMesh() {
		mesh.Clear();					// Clear Mesh
		mesh.vertices = vertices;		// Draw Vertices
		mesh.triangles = triangles;		// Draw Triangles
		mesh.RecalculateNormals();		// Normalize Lighting
	}
}
