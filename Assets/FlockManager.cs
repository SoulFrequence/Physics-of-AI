using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{

    public GameObject fishPrefab;

    public int numbFish = 20;

    public GameObject[] allFish;

    public Vector3 swimLims = new Vector3(5, 5, 5);

    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float nDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
        allFish = new GameObject[numbFish];

        for (int i = 0; i < numbFish; i++){

            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLims.x, swimLims.x), Random.Range(-swimLims.y, swimLims.y), Random.Range(-swimLims.z, swimLims.z));

            allFish[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity);

            allFish[i].GetComponent<Flock>().myManager = this;
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
