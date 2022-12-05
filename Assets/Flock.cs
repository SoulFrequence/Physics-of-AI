using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{

    public FlockManager myManager;

    float speed;

    bool turning = false;

    // Start is called before the first frame update
    void Start()
    {
        
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);

    }

    void ApplyRules(){

        GameObject[] gos;

        gos = myManager.allFish;

        Vector3 vCenter = Vector3.zero;
        Vector3 vaVoid = Vector3.zero;

        float gSpeed = 0.01f;
        float neighbourDistance;
        int groupSize = 0;

        foreach (GameObject go in gos){

            if(go != this.gameObject){

                neighbourDistance = Vector3.Distance(go.transform.position,this.transform.position);

                if(neighbourDistance <= myManager.nDistance){

                    vCenter += go.transform.position;

                    groupSize++;

                    if(neighbourDistance < 1.0f){

                        vaVoid = vaVoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();

                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if(groupSize > 0){

            vCenter = vCenter / groupSize + (myManager.goalPos - this.transform.position);

            speed = gSpeed / groupSize;

            Vector3 direction = (vCenter + vaVoid) - transform.position;

            if(direction != Vector3.zero){

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Bounds b = new Bounds(myManager.transform.position, myManager.swimLims * 2);

        if (!b.Contains(transform.position)){

            turning = true;
        } else {

            turning = false;
        }

        if (turning){

            Vector3 direction = myManager.transform.position - transform.position;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
        } else {

            if(Random.Range(0, 100) < 10){
                
            speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
            }

            if(Random.Range(0, 100) < 20){
            ApplyRules();
            }
        }

        transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
