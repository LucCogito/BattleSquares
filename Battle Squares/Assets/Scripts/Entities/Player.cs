using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ShapeEntity
{
    [SerializeField]
    private float _maxSpeed, _acceleration;

    private void Awake()
    {
        _inputSource = new KeyboardMouseInput();
    }

    private void Start()
    {
        _movement = new EightDirectionMovement(_rigidbody, _maxSpeed, _acceleration);
    }

    public void SetTestParameters(float maxSpeed, float acceleration)
    {
        _maxSpeed = maxSpeed;
        _acceleration = acceleration;
    }

    public void SetTestInputSource(IInputSource inputSource) => _inputSource = inputSource; 
    public void SetTestRigidbody(Rigidbody2D rigidbody) => _rigidbody = rigidbody;
}
