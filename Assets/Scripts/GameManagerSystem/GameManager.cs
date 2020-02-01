using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameState _gameState;

    public static GameManager Instance { get; private set; }

    public Action<GameState> OnGameStateChanged;

    public GameState GameState
    {
        get { return _gameState; }

        set
        {
            _gameState = value;
            OnGameStateChanged?.Invoke(_gameState);
            if (_gameState == GameState.GameOver || _gameState == GameState.Win)
            {
                Restart();
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        Application.targetFrameRate = 60;
    }

    public void Restart()
    {
        StartCoroutine(_Restart());
    }

    private IEnumerator _Restart()
    {
        yield return new WaitForSeconds(3f);
        GameState = GameState.Restart;
        SceneManager.LoadScene(0);

    }
}
