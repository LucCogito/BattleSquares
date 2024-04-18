using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuUi, _gameplayUi, _pauseScreen, _audioSlider;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.instance;
        _gameManager.OnGameStateChanged += AdjustUiToGameState;
    }

    private void OnDestroy()
    {
        _gameManager.OnGameStateChanged -= AdjustUiToGameState;
    }

    public void StartNewGame() => _gameManager.StartNewGame();

    public void ReturnToMainMenu() => _gameManager.ReturnToMainMenu();

    private void AdjustUiToGameState(GameState state)
    {
        switch (state)
        {
            case GameState.InMenu:
                _menuUi.SetActive(true);
                _gameplayUi.SetActive(false);
                break;
            case GameState.InGame:
                _menuUi.SetActive(false);
                _gameplayUi.SetActive(true);
                _pauseScreen.SetActive(false);
                _audioSlider.SetActive(false);
                break;
            case GameState.Paused:
                _pauseScreen.SetActive(true);
                _audioSlider.SetActive(true);
                break;
            default:
                Debug.Log(gameObject + ": Unknown game state reached!");
                break;
        }
    }
}
