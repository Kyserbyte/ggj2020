using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float vel = 0f;

    [Range(10,300)]
    public float MAX_VEL = 50f;

    void Start()
    {
        
    }

    void Update()
    {
        vel = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel = -MAX_VEL;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel = MAX_VEL;
        }

        transform.RotateAround(Vector3.zero, Vector3.forward, vel * Time.deltaTime);


    }

    private void FixedUpdate()
    {
        
    }
}
