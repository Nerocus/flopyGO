using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Run : MonoBehaviour
{

    public float speed;

    void Start()
    {
        
    }

   
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
