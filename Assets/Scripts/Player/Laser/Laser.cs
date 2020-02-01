using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    Vector3 scaleChange;
    void Start()
    {
        scaleChange = new Vector3(0.66f, 0);
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (transform.localScale.x <= 2)
            {
                transform.localScale += scaleChange;
            }
            
        } 
        if(Input.GetKeyUp(KeyCode.Space)) {
            transform.localScale = new Vector3(0.05f, 1, 1);
        }
    }
}
