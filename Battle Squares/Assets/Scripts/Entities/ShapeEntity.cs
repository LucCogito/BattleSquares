using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShapeEntity : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D _rigidbody;

    protected IInputSource _inputSource;
    protected Movement _movement;

    private void Update()
    {
        _inputSource.Tick();
    }

    private void FixedUpdate()
    {
        _movement.Tick(_inputSource.MoveVector, Time.fixedDeltaTime);
    }
}
