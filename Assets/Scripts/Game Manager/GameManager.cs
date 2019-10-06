using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject firstCharacter;
	// Start is called before the first frame update
	void Start()
    {
		Vector3 pos = new Vector3(0,100,0);
		if (Physics.Raycast(pos, Vector3.down, out RaycastHit hit) && hit.transform.tag == "Ground") {
			Vector3 finalPos = hit.point;
			Instantiate(firstCharacter, finalPos, Quaternion.identity);
		}
		
    }
}
