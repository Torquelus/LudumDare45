using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWASD : MonoBehaviour
{
   
    public float speed = 10;//speed of movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // obtained from https://forum.unity.com/threads/moving-character-relative-to-camera.383086/ 
        //thank you!

        //reading the input:
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        //assuming we only using the single camera:
        var camera = Camera.main;

        //camera forward and right vectors:
        var forward = camera.transform.forward;
        var right = camera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        //this is the direction in the world space we want to move:
        var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;

        //now we can apply the movement:
        transform.Translate(desiredMoveDirection * speed * Time.deltaTime);
    }
}
