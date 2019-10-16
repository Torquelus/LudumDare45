using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;
    private NavMeshAgent agent;
    private bool selected = false;
    //private Animator skeleton;

    //public Material selectedcolor;
    //public Material deselectedcolor;

    private void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        cam = Camera.main;

        NavMeshHit closestHit; //moves prefab onto navmesh to ensure navmeshagent can move
        if (NavMesh.SamplePosition(transform.position, out closestHit, 100f, NavMesh.AllAreas))
        {
            transform.position = closestHit.position;
            agent.enabled = true;
        }

        //skeleton = this.gameObject.GetComponent<Animator>(); //for editing animator
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //left click to select
        {
            Ray selectorray = cam.ScreenPointToRay(Input.mousePosition); //selectorray pointing to our selected unit
            RaycastHit selected_unit;



            if (Physics.Raycast(selectorray, out selected_unit)) //if there is a hit to a selectable object
            {
                if (selected_unit.collider.transform == this.transform)
                {//selects unit of it was hit
                    selected = true;
                    //GetComponent<Renderer>().material = selectedcolor; ; //changes color


                }
            }

        }
        else if (Input.GetMouseButtonDown(1) && selected == true)
        { //if right clicked and selected, the unit will move

            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //ray is a Ray pointing to our cursor
            RaycastHit hit; //hit stores the point it hits on the NavMeshSurface

            if (Physics.Raycast(ray, out hit)) //if there is a hit
            {
                //moves agent or player
                agent.SetDestination(hit.point); //will pathfind player to hit
            }

            selected = false;


            //GetComponent<Renderer>().material = deselectedcolor; ; //changes color

        }

        if (agent.isOnNavMesh == false) //if player body is not on a navmesh surface
        {
            agent.updateUpAxis = true; //moves player to surface

        }
        /*
            if (agent.isOnNavMesh == false) //if they are still not on a navmesh, have them fall slowly if positive or raise if negative Y
            {
                if (agent.transform.position.y >= 30)
                {
                    agent.transform.Translate(0f, -0.1f, 0f); //moves agent up by one
                }

                if (agent.transform.position.y < 30)
                {
                    agent.transform.Translate(0f, +0.1f, 0f); //moves agent up by one
                } 

            }
            




        }
        */
    }
}
