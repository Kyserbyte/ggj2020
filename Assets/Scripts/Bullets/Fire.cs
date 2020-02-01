using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force;
    public float randomness = 1;

    private void Awake()
    {
        GameManager.Instance.OnGameStateChanged += _OnGameStateChanged;
    }

    void _OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Play:
                Explosion(20);
                StartCoroutine(_ScheduleExplosion());
                break;
            default:
                break;
        }
    }


    void Start()
    {
        GenerateBullets();
    }

    void Update()
    {

    }

    public void Explosion(int num)
    {
        StartCoroutine(_Explosion(num));
    }

    public void GenerateBullets()
    {
        StartCoroutine(_GenerateBullets());
    }

    private IEnumerator _ScheduleExplosion()
    {
        yield return new WaitForSeconds(Random.Range(8f, 15f));
        Explosion(Random.Range(5,20));
        StartCoroutine(_ScheduleExplosion());
    }

    private IEnumerator _GenerateBullets()
    {
        while (true)
        {
            if (GameManager.Instance.GameState == GameState.Play)
            {
                _SpawnBullet();
            }
            yield return new WaitForSeconds(Random.Range(.2f,1f));
        }
    }

    private IEnumerator _Explosion(int num)
    {
        while (num > 0 && GameManager.Instance.GameState == GameState.Play)
        {
            _SpawnBullet();
            num--;
            yield return new WaitForEndOfFrame();
        }
    }

    private void _SpawnBullet()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);

        //Temporary_Bullet_Handler.transform.localPosition += new Vector3(directionX * Bullet_Forward_Force, directionY * Bullet_Forward_Force);

        Rigidbody2D Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();

        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
        Temporary_RigidBody.AddForce(new Vector3(Random.Range(-1f, 1f) * Bullet_Forward_Force, Random.Range(-1f, 1f) * Bullet_Forward_Force), ForceMode2D.Impulse);
    }
}
