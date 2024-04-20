using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    [SerializeField]
    private InputAction _moveAction;
    [SerializeField]
    private InputAction _ability1Action;
    [SerializeField]
    private InputAction _ability2Action;
    [SerializeField]
    private InputAction _pauseAction;

    public event Action OnAbility1Action, OnAbility2Action, OnPauseAction;

    public Vector2 MoveActionVector { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        _moveAction.Enable();
        _ability1Action.Enable();
        _ability2Action.Enable();
        _pauseAction.Enable();
        _moveAction.performed += (context) => MoveActionVector = context.ReadValue<Vector2>();
        _moveAction.canceled += (context) => MoveActionVector = Vector2.zero;
        _ability1Action.performed += (context) => OnAbility1Action?.Invoke();
        _ability2Action.performed += (context) => OnAbility2Action?.Invoke();
        _pauseAction.performed += (context) => OnPauseAction?.Invoke();
    }

    private void OnDestroy()
    {
        _moveAction.Disable();
        _ability1Action.Disable();
        _ability2Action.Disable();
        _pauseAction.Disable();
    }
}
