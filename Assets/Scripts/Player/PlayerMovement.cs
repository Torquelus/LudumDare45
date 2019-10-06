using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetMouseButtonDown(1))
        { //if left clicked

            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //ray is a Ray pointing to our cursor
            RaycastHit hit; //hit stores the point it hits on the NavMeshSurface

            if (Physics.Raycast(ray, out hit)) //if there is a hit
            { 
                //moves agent or player
                agent.SetDestination(hit.point); //will pathfind player to hit
            }


        }

        if (agent.isOnNavMesh==false) //if player body is not on a navmesh surface
        {
            agent.updateUpAxis = true; //moves player to surface
        }


    }
}
