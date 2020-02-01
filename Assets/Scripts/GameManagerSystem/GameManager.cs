using System;
using UnityEngine;

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
            OnGameStateChanged?.Invoke(this._gameState);
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
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
