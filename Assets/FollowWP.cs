using UnityEngine;

public class FollowWP : MonoBehaviour {

    public GameObject[] waypoints;

    int currentWaypoint = 0;

    public float speed = 10.0f;
 
    public float rotationSpeed = 10.0f;

    public float lookAhead = 10.0f;

   
    GameObject tracker;

    void Start() {

      
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
     
        DestroyImmediate(tracker.GetComponent<Collider>());
    
        tracker.GetComponent<MeshRenderer>().enabled = false;

        tracker.transform.position = this.transform.position;

        tracker.transform.rotation = this.transform.rotation;
    }

    void ProcessTracker() {

       
        if (Vector3.Distance(tracker.transform.position, this.transform.position) > lookAhead) return;

       
        if (Vector3.Distance(tracker.transform.position, waypoints[currentWaypoint].transform.position) < 3.0f) {

        
            currentWaypoint++;
        }

      
        if (currentWaypoint >= waypoints.Length) {

        
            currentWaypoint = 0;
        }

        
        tracker.transform.LookAt(waypoints[currentWaypoint].transform);
        
        tracker.transform.Translate(0.0f, 0.0f, (speed + 20.0f) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update() {

        
        ProcessTracker();

        Quaternion lookAtWayPoint = Quaternion.LookRotation(tracker.transform.position - this.transform.position);
        
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookAtWayPoint, rotationSpeed * Time.deltaTime);
        
        this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }
}