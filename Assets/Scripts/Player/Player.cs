using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float vel = 0f;

    [Range(10, 300)]
    public float MAX_VEL = 50f;
    public Sprite frame0, frame1, frame2;

    int timer = 0;
    public int MAX_FRAME = 3;

    void Start()
    {

    }

    void Update()
    {
        vel = 0f;
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.Space))
        {
            vel = -MAX_VEL;
        }
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.Space))
        {
            vel = MAX_VEL;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (timer == 0)
            {
                GetComponent<SpriteRenderer>().sprite = frame1;
            }
            else if (timer == MAX_FRAME)
            {
                GetComponent<SpriteRenderer>().sprite = frame2;
            }
            timer++;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            timer = 0;
            GetComponent<SpriteRenderer>().sprite = frame0;
        }

        transform.RotateAround(Vector3.zero, Vector3.forward, vel * Time.deltaTime);


    }

    private void FixedUpdate()
    {

    }
}
