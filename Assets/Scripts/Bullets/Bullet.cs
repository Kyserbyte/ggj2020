using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    SpriteRenderer sprite;
    public Sprite[] sprites;
    float spin;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 2)];
        spin = Random.Range(0.1f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState == GameState.Play)
        {
            transform.Rotate(Vector3.forward, spin);
            if (Vector3.Distance(Vector3.zero, transform.position) >= 45)
            {
                Destroy(gameObject);
            }
        }
    }
}
