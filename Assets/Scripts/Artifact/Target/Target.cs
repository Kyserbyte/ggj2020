﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Vector3 scaleChange = new Vector3(0.5f, 0.5f);
    Vector3 targetScale = new Vector3(3f, 3f, 3f);

    public float MAX_HP = 100f;
    public float HITS_TO_WIN = 20f;
    public float INIT_HP;

    public ParticleSystem particle;

    public float coreHp;

    private void Awake()
    {
        GameManager.Instance.OnGameStateChanged += _OnGameStateChanged;
    }

    void _OnGameStateChanged(GameState state)
    {
        switch(state)
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
        coreHp = INIT_HP;
    }

    void Start()
    {
        _Init();
        NewTarget();
    }

    private void NewTarget()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        transform.RotateAround(Vector3.zero, Vector3.forward, Random.Range(0f, 360f));
    }

    void Update()
    {
        if (GameManager.Instance.GameState == GameState.Play)
        {
            if (transform.localScale.x >= targetScale.x)
            {
                transform.localScale = targetScale;
                UpdateHp(-1f * Time.deltaTime);
                //NewTarget();
            } else if ((transform.localScale.x >= targetScale.x/2))
            {
                transform.localScale += scaleChange * Time.deltaTime;
                UpdateHp(-0.3f * Time.deltaTime);
            }
            else
            {
                transform.localScale += scaleChange * Time.deltaTime;
            }

        }

    }

    void UpdateHp(float hit)
    {
        coreHp += hit * (MAX_HP / HITS_TO_WIN) * (hit > 0 ? 1f : 1.5f);
        if (coreHp >= MAX_HP)
        {
            _Win();
        }
        if (coreHp <= 0)
        {
            _Defeat();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Laser laser = other.GetComponent<Laser>();
        if (laser == null) return;
        UpdateHp(1);
        NewTarget();
        particle.Play();
    }

    private void _Defeat()
    {
        Debug.Log("Defeat from Target HP: " + coreHp);
        GameManager.Instance.GameState = GameState.GameOver;
    }

    private void _Win()
    {
        GameManager.Instance.GameState = GameState.Win;
    }
}
