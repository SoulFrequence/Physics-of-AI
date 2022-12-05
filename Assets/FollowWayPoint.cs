using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoint : MonoBehaviour
{

    public GameObject[] waypoints;

    int currentWayPoint = 0;

    public float speed = 10.0f;

    public float rotationSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWayPoint].transform.position) < 10){

            currentWayPoint++;
        }

        if (currentWayPoint >= waypoints.Length){

            currentWayPoint = 0;

        }

        //this.transform.LookAt(waypoints[currentWayPoint].transform);

        Quaternion lookAtWayPoint = Quaternion.LookRotation(waypoints[currentWayPoint].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWayPoint, rotationSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
