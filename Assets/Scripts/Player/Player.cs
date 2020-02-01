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
    public float LIVES = 5;
    public float MAX_HP = 100;
    public float playerHp;

    void Start()
    {
        playerHp = MAX_HP;
    }

    void Update()
    {
        if(playerHp <= 0)
        {
            Debug.Log("Defeat");
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerHp -= MAX_HP / LIVES;
    }
}
