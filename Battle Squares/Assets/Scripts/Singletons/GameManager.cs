using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private InputManager _inputManager;

    private GameState GameState
    {
        get => _gamestate;
        set
        {
            _gamestate = value;
            OnGameStateChanged?.Invoke(value);
        }
    }
    private GameState _gamestate;

    public event Action<GameState> OnGameStateChanged;

    protected override void Awake()
    {
        base.Awake();
        _inputManager = InputManager.instance;
        _inputManager.OnPauseAction += TryPauseGame;
    }

    private void OnDestroy()
    {
        _inputManager.OnPauseAction -= TryPauseGame;
    }

    public void StartNewGame()
    {
        GameState = GameState.InGame;
    }

    public void ReturnToMainMenu()
    {
        GameState = GameState.InMenu;
    }

    private void TryPauseGame()
    {
        if (GameState != GameState.InMenu)
            GameState = (GameState == GameState.InGame ? GameState.Paused : GameState.InGame);
    }
}

public enum GameState
{
    InMenu,
    InGame,
    Paused,
}