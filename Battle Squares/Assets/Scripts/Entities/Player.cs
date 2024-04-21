using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ShapeEntity
{
    [SerializeField]
    private float _maxSpeed, _acceleration;
    [SerializeField]
    private AbilitySystem _abilitySystem;

    private void Awake()
    {
        _inputSource = new KeyboardMouseInput();
    }

    private void Start()
    {
        _movement = new EightDirectionMovement(_rigidbody, _maxSpeed, _acceleration);
        _abilitySystem?.Initialize(_inputSource);
    }

    protected override void Update()
    {
        base.Update();
        _abilitySystem?.Tick();
    }

    public void SetTestParameters(float maxSpeed, float acceleration)
    {
        _maxSpeed = maxSpeed;
        _acceleration = acceleration;
    }

    public void SetTestInputSource(IInputSource inputSource) => _inputSource = inputSource; 
    public void SetTestRigidbody(Rigidbody2D rigidbody) => _rigidbody = rigidbody;
}
