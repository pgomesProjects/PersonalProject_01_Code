using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class PlatformController : MonoBehaviour
{

    //Time between patrol destinations
    public float patrolTime = 15f;
    public float patrolTimeMoving = 3f;

    //Waypoints that define the control area, like nodes
    public List<Transform> waypoints;
    private int index;
    private float usedPatrolTime;
    private float moveTimer;

    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        usedPatrolTime = patrolTime;

        //Calls the Tick method every 0.5 seconds
        InvokeRepeating("Tick", 0f, 0.5f);

        if(waypoints.Count > 0)
        {
            //First patrol point takes half of the time to move
            Invoke("Patrol", patrolTime / 2);
        }
    }

    void Patrol()
    {
        moveTimer = 0;
        //In-line ternary method: if the index reached the end of the array, set to 0, if not, at 1 to index
        index = index == waypoints.Count - 1 ? 0 : index + 1;

        Debug.Log("Index: " + index);
        //Depending on the index, change the patrol time
        //Patrol Time Moving: Patrol Time When Moving Corners
        //Patrol Time: Patrol Time For Longer Distances / Waiting For User
        switch (index)
        {
            case 1:
                usedPatrolTime = patrolTimeMoving;
                break;

            case 4:
                usedPatrolTime = patrolTimeMoving;
                break;

            default:
                usedPatrolTime = patrolTime;
                break;
        }

    }//end of Patrol

    void FixedUpdate()
    {
        moveTimer += Time.deltaTime;
        //When the patrol time is reached, switch to a new waypoint
        if (moveTimer >= usedPatrolTime)
        {
            Patrol();
        }
    }

    void Tick()
    {
        //Continues moving the object towards the current waypoint
        agent.destination = waypoints[index].position;

    }//end of Tick

    public void AddPatrolPoint(Transform newPatrol)
    {
        //Adds a new point to the patrol list
        waypoints.Add(newPatrol);
    }//end of AddPatrolPoint

}
