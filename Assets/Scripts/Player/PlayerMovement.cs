using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetMouseButtonDown(0))
        { //if left clicked

            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //ray is a Ray pointing to our cursor
            RaycastHit hit; //hit stores the point it hits on the NavMeshSurface

            if (Physics.Raycast(ray, out hit)) //if there is a hit
            { 
                //moves agent or player
                agent.SetDestination(hit.point); //will pathfind player to hit
            }


        }

    }
}
