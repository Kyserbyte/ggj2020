using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    Vector3 scaleChange, posChange;
    void Start()
    {
        scaleChange = new Vector3(4, 0);
        posChange = new Vector3(6, 0);
    }

    void Update()
    {
        if (GameManager.Instance.GameState == GameState.Play)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (transform.localScale.x < 12)
                {
                    transform.localScale += scaleChange;
                    transform.localPosition += posChange;
                }

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                transform.localScale = new Vector3(0, 4);
                transform.localPosition = new Vector3(0.4f, 0);
            }
        }
    }
}
