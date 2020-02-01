using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Vector3 scaleChange = new Vector3(-0.003f, -0.003f);
    void Start()
    {
        newTarget();
    }

    private void newTarget()
    {
        transform.localScale = new Vector3(0.55f, 0.55f, 0.5f);
        transform.RotateAround(Vector3.zero, Vector3.forward, Random.Range(0f, 360f));
    }

    void Update()
    {
        transform.localScale += scaleChange;
        if(transform.localScale.x <= 0)
        {
            newTarget();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        newTarget();
    }
}
