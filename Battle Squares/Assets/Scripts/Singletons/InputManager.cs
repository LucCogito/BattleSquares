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

    public event Action OnPauseAction;

    public Vector2 MoveActionVector { get; private set; }
    public bool IsAbility1Performed { get; private set; }
    public bool IsAbility2Performed { get; private set; }
    public Vector2 MousePositon => Mouse.current.position.ReadValue();

    protected override void Awake()
    {
        base.Awake();
        _moveAction.Enable();
        _ability1Action.Enable();
        _ability2Action.Enable();
        _pauseAction.Enable();
        _moveAction.performed += (context) => MoveActionVector = context.ReadValue<Vector2>();
        _moveAction.canceled += (context) => MoveActionVector = Vector2.zero;
        _ability1Action.performed += (context) => IsAbility1Performed = true;
        _ability1Action.canceled += (context) => IsAbility1Performed = false;
        _ability2Action.performed += (context) => IsAbility2Performed = true;
        _ability2Action.canceled += (context) => IsAbility2Performed = false;
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
