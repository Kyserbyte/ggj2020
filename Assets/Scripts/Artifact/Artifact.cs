using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{

    public Sprite[] core;
    int i = 0;
    int timer = 0;
    public int MAX_FRAME = 3;

    // Update is called once per frame
    void Update()
    {
        if(timer == MAX_FRAME) { 
            if(i > 3)
            {
                i = 0;
            }
            GetComponent<SpriteRenderer>().sprite = core[i];
            i++;
            timer = -1;
        }
        timer++;
    }
}
