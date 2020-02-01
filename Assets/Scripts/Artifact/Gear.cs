using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    void Start()
    {
        speed = Random.Range(-5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState == GameState.Play)
        {
            transform.Rotate(Vector3.forward, 1 * speed);
        }
    }
}
