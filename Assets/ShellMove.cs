using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMove : MonoBehaviour
{
    float speed = 1;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, (Time.deltaTime * speed)/2.0f, Time.deltaTime * speed);       
    }
}
