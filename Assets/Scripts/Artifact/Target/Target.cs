using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Vector3 scaleChange = new Vector3(-0.003f, -0.003f);

    public float MAX_HP = 100f;
    public float HITS_TO_WIN = 20f;

    public float coreHp;

    void Start()
    {
        coreHp = 11f;
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
        if (transform.localScale.x <= 0)
        {
            UpdateHp(-1);
            newTarget();
        }
    }

    void UpdateHp(int hit)
    {
        coreHp += hit * (MAX_HP / HITS_TO_WIN) * (hit > 0 ? 1f : 2f);
        if(coreHp >= MAX_HP)
        {
            Debug.Log("Victory");
        }
        if(coreHp <= 0)
        {
            Debug.Log("Defeat");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        UpdateHp(1);
        newTarget();
    }
}
