using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force;
    public float randomness = 1;
    public float magic = 11;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

            //Temporary_Bullet_Handler.transform.localPosition += new Vector3(directionX * Bullet_Forward_Force, directionY * Bullet_Forward_Force);

            Rigidbody2D Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(new Vector3(Random.Range(-1f, 1f) * Bullet_Forward_Force, Random.Range(-1f, 1f) * Bullet_Forward_Force), ForceMode2D.Impulse);
            if (((Temporary_Bullet_Handler.transform.localPosition.x * Temporary_Bullet_Handler.transform.localPosition.x) + (Temporary_Bullet_Handler.transform.localPosition.y * Temporary_Bullet_Handler.transform.localPosition.y)) >= 169f)
            {
                Destroy(Temporary_Bullet_Handler);

            }
        }
    }
}
