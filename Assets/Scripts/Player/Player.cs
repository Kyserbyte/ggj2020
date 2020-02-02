using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float vel = 0f;

    [Range(10, 300)]
    public float MAX_VEL = 50f;
    public Sprite frame0, frame1, frame2;
    public Vector3 initPos;

    int timer = 0;
    public int MAX_FRAME = 3;
    public float LIVES = 5;
    public float MAX_HP = 100;
    public float playerHp;
    bool invulnerable = false;

    private void Awake()
    {
        GameManager.Instance.OnGameStateChanged += _OnGameStateChanged;
    }

    void _OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Restart:
                _Init();
                break;
            default:
                break;
        }
    }

    private void _Init()
    {
        playerHp = MAX_HP;
        transform.localPosition = initPos;
        transform.localRotation = Quaternion.identity;
    }

    void Start()
    {
        _Init();
    }

    void Update()
    {
        if (GameManager.Instance.GameState == GameState.Play)
        {
            if (playerHp <= 0)
            {
                _Defeat();
                return;
            }
            vel = 0f;
            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.Space))
            {
                vel = -MAX_VEL;
                SoundManager.instance.PlaySingle("Gear", 0.3f);
            }
            if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.Space))
            {
                vel = MAX_VEL;
                SoundManager.instance.PlaySingle("Gear", 0.3f);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (timer == 0)
                {
                    GetComponent<SpriteRenderer>().sprite = frame1;
                }
                else if (timer == MAX_FRAME)
                {
                    GetComponent<SpriteRenderer>().sprite = frame2;
                }
                timer++;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                timer = 0;
                GetComponent<SpriteRenderer>().sprite = frame0;
            }

            transform.RotateAround(Vector3.zero, Vector3.forward, vel * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if (bullet != null && !invulnerable)
        {
            playerHp -= MAX_HP / LIVES;
            invulnerable = true;
            StartCoroutine(Invulnerability());
        }
    }

    IEnumerator Invulnerability()
    {
        StartCoroutine(Blink());
        yield return new WaitForSeconds(2);
        invulnerable = false;
    }

    IEnumerator Blink()
    {
        while (invulnerable)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }


    private void _Defeat()
    {
        Debug.Log("Defeat from Player HP: " + playerHp);
        GameManager.Instance.GameState = GameState.GameOver;
    }
}
