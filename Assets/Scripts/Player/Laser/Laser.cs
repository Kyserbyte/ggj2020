using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    Vector3 scaleChange, posChange;

    private void Awake()
    {
        GameManager.Instance.OnGameStateChanged += _OnGameStateChanged;
    }

    void _OnGameStateChanged(GameState state)
    {
        switch(state)
        {
            case GameState.Restart:
            case GameState.GameOver:
            case GameState.Win:
                _Init();
                break;
            default:
                break;
        }
    }


    private void _Init()
    {
        transform.localScale = new Vector3(0, 4, 0);
        transform.localPosition = Vector3.zero;
        scaleChange = new Vector3(4, 0);
        posChange = new Vector3(6, 0);
    }

    void Start()
    {
        _Init();
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
                SoundManager.instance.PlaySingle("Laser");
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                transform.localScale = new Vector3(0, 4);
                transform.localPosition = new Vector3(0.4f, 0);
            }
        }
    }
}
