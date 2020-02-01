using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{

    public Sprite[] core;
    int i = 0;
    Target target;
    // Update is called once per frame
    void Update()
    {
        target = GetComponentsInChildren<Target>()[0];
        
        if(target.coreHp < target.MAX_HP / 5)
        {
            i = 4;
        }
        else if (target.coreHp < (target.MAX_HP / 5) * 2)
        {
            i = 3;
        }
        else if (target.coreHp < (target.MAX_HP / 5) * 3)
        {
            i = 2;
        }
        else if (target.coreHp < (target.MAX_HP / 5) * 4)
        {
            i = 1;
        }
        else if (target.coreHp < target.MAX_HP)
        {
            i = 0;
        }
        GetComponent<SpriteRenderer>().sprite = core[i];
    }
}
