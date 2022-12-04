using UnityEngine;

public class AIControl : MonoBehaviour {

    GameObject[] goalLocations;
    UnityEngine.AI.NavMeshAgent agent;
    Animator animation;


    // Use this for initialization
    void Start() {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        animation = this.GetComponent<Animator>();
        animation.SetFloat("walkingOffset", Random.Range(0,1));
        animation.SetTrigger("isWalking");
        float speedmult = Random.Range(0.1f,1.5f);
        animation.SetFloat("speedMultiplier", speedmult);
        agent.speed *= speedmult;
    } 

    // Update is called once per frame
    void Update() {

        if (agent.remainingDistance < 1) {

            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }
}
