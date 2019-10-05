using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
	Mesh mesh;

	Vector3[] vertices;
	int[] triangles;

	public int xSize = 20;
	public int zSize = 20;

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

		for (int i = 0, z = 0; z <= zSize; z++) {
			for (int x = 0; x <= xSize; x++) {
				float y = Mathf.PerlinNoise(x * 0.3f, z * 0.3f) * 2.0f;
				vertices[i] = new Vector3(x, y, z);
				i++;
			}
		}
		triangles = new int[xSize * zSize * 6];

		for (int vert = 0, tries = 0,  z = 0; z < zSize; z++) { 
			for (int x = 0; x < xSize; x++) {
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
