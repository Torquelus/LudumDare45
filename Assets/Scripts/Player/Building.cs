using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour{

    // Public bool if can be placed
    public bool canPlace;

    // Objects currently colliding with
    public List<GameObject> collisions;

    // Start
    private void Start() {
        canPlace = true;
    }

    // Check on collision enter
    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag != "Ground") {
            collisions.Add(collision.gameObject);
            canPlace = false;
        }
        if(collisions.Count > 0) {
            canPlace = false;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.transform.tag != "Ground") {
            collisions.Remove(collision.gameObject);
        }
        if(collisions.Count == 0) {
            canPlace = true;
        }
    }
}
