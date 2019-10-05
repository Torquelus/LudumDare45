using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
	Mesh mesh;

	Vector3[] vertices;
	int[] triangles;

	public int xSize = 10;
	public int zSize = 10;
	public float noiseY = 1.0f;
	public float noiseX = 0.3f;
	public float noiseZ = 0.3f;
	public int multiplier = 100;

    // Start is called before the first frame update
    void Start()
    {
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		CreateShape();
		UpdateMesh();
    }

	void CreateShape() {
		vertices = new Vector3[(xSize + 1) * (zSize + 1)];

		for (int i = 0, z = -zSize/2; z <= zSize/2; z++) {
			for (int x = -xSize/2; x <= xSize/2; x++) {
				float y = Mathf.PerlinNoise(x * noiseX, z * noiseZ) * noiseY;
				vertices[i] = new Vector3(x * multiplier, y * multiplier, z * multiplier);
				i++;
			}
		}
		triangles = new int[xSize * zSize * 6];

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

	void UpdateMesh() {
		mesh.Clear();
		mesh.vertices = vertices;
		mesh.triangles = triangles;

		mesh.RecalculateNormals();
	}
}
