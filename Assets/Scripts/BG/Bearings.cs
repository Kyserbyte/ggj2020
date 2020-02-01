using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bearings : MonoBehaviour
{
    SpriteRenderer sprite;
    public int ANGLE = 6;
    int dirBall = 1;
    int dirWheel = 0;
    float ballSpeed = 1.4f;
    ArrayList sprites = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);

        // Generate a child prefab of the sprite renderer
        GameObject childPrefab = new GameObject();
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        childPrefab.transform.position = transform.position;
        childSprite.sprite = sprite.sprite;
        childSprite.GetComponent<SpriteRenderer>().sortingOrder = 1;
        sprites.Add(childPrefab);
        // Loop through and spit out repeated tiles
        GameObject child;
        for (int i = 1, l = 360 / ANGLE; i < l; i++)
        {
            child = Instantiate(childPrefab) as GameObject;
            child.transform.RotateAround(Vector3.zero, Vector3.forward, ANGLE * i);
            child.GetComponent<SpriteRenderer>().sortingOrder = 1;
            child.transform.parent = transform;
            sprites.Add(child);
        }

        // Set the parent last on the prefab to prevent transform displacement
        childPrefab.transform.parent = transform;

        // Disable the currently existing sprite component since its now a repeated image
        sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.Space))
        {
            dirBall = 1;
            ballSpeed = 1.4f;
            dirWheel = 1;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.Space))
        {
            dirBall = -1;
            ballSpeed = 1.4f;
            dirWheel = -1;
        }
        else
        {
            dirWheel = 0;
            if(ballSpeed >= 0.05f) { 
                ballSpeed -= 0.05f;
            }
        }
        foreach (GameObject sprite in sprites) {
            sprite.transform.RotateAround(Vector3.zero, Vector3.forward, 0.09f * dirWheel);
            sprite.transform.Rotate(Vector3.forward, ballSpeed * dirBall);
        }
    }
}
