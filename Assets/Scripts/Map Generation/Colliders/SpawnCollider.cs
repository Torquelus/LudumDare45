using UnityEngine;

public class SpawnCollider : MonoBehaviour {

	// On Trigger Enter
	private void OnTriggerEnter(Collider other) {

		// Random Pos
		int randX = Random.Range(10, 20);
		int randZ = Random.Range(10, 20);

		// Change Pos
		Vector3 tempPos = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randZ);

		// Find Ground - if Ground exists instantiate on ground else destroy
		if (Physics.Raycast(tempPos, Vector3.down, out RaycastHit hit) && hit.transform.tag == "Ground") {
			other.transform.position = tempPos;
		}
		else {
			Destroy(other);
		}
	}
}
