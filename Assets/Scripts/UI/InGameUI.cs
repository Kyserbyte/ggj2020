﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject countDownPanel;
    public TextMeshProUGUI countDownText;
    public TextMeshProUGUI gameEndText;
    public Image playerHp;
    public Player player;
    public int countDownFrom;

    private int _countDown;

    private void Awake()
    {
        GameManager.Instance.GameState = GameState.Pause;
        GameManager.Instance.OnGameStateChanged += _OnGameStateChanged;
    }

    private void _Init()
    {
        _countDown = countDownFrom;
        countDownPanel.SetActive(true);
        countDownText.gameObject.SetActive(false);
        gameEndText.gameObject.SetActive(false);
    }

    private void _OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.GameOver:
                _Init();
                gameEndText.text = "GAME OVER";
                gameEndText.gameObject.SetActive(true);
                break;
            case GameState.Win:
                _Init();
                gameEndText.text = "YOU WIN!";
                gameEndText.gameObject.SetActive(true);
                break;
            case GameState.Restart:
                _Init();
                StartCountdown();
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _Init();
        StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        playerHp.fillAmount = player.playerHp / player.MAX_HP;
    }

    public void StartCountdown()
    {
        countDownText.text = _countDown.ToString();
        countDownText.gameObject.SetActive(true);
        StartCoroutine(_Countdown());
    }

    private IEnumerator _Countdown()
    {
        while (_countDown > 0)
        {
            yield return new WaitForSeconds(1.0f);
            _countDown--;
            countDownText.text = _countDown.ToString();
        }
        _CountdownEnd();
    }

    private void _CountdownEnd()
    {
        countDownPanel.SetActive(false);
        GameManager.Instance.GameState = GameState.Play;
    }
}
