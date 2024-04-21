using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightDirectionMovement : Movement
{
    private float _minMoveVectorSqrMagnitude = .1f, _minSpeedSqr = .05f;

    public EightDirectionMovement(Rigidbody2D rigidbody, float maxSpeed, float acceleration) : base(rigidbody)
    {
        _maxSpeed = maxSpeed;
        _maxSpeedSqr = maxSpeed * maxSpeed;
        _acceleration = acceleration;
    }

    public override void Tick(Vector2 moveVector, float timeDelta)
    {
        if (moveVector.sqrMagnitude > 1f)
            moveVector.Normalize();
        _rigidbody.velocity += moveVector * _acceleration * timeDelta;
        if (moveVector.sqrMagnitude < _minMoveVectorSqrMagnitude)
        {
            if (_rigidbody.velocity.sqrMagnitude > _minSpeedSqr)
                _rigidbody.velocity -= _rigidbody.velocity.normalized * _acceleration * timeDelta;
            else
                _rigidbody.velocity = Vector2.zero;
        }
        else if (_rigidbody.velocity.sqrMagnitude > _maxSpeedSqr)
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
    }
}
