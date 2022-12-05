using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    
    float speed = 5.0f;

    float accuracy = 1.0f;

    float rotationSpeed = 2.0f;

    public GameObject wpManager;
    
    GameObject[] wps;

    GameObject currentNode;

    int currentWayPoint = 0;

    Graph g;

    // Start is called before the first frame update
    void Start()
    {
        
        wps = wpManager.GetComponent<WaypointManager>().waypoints;

        g = wpManager.GetComponent<WaypointManager>().graph;

        currentNode = wps[0];
    }


    public void ReturnToStart(){

        g.AStar(currentNode, wps[16]);

        currentWayPoint = 0;
    }

    public void GoToRuin(){

        g.AStar(currentNode, wps[4]);

        currentWayPoint = 0;
    }

    void LateUpdate() {
   
        if(g.getPathLength() == 0 || currentWayPoint == g.getPathLength()){

            return;
        }

        currentNode = g.getPathPoint(currentWayPoint);

        if(Vector3.Distance(g.getPathPoint(currentWayPoint).transform.position, transform.position) < accuracy){

            currentWayPoint++;
        }

        if(currentWayPoint < g.getPathLength()){

            goal = g.getPathPoint(currentWayPoint).transform;

            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);

            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
