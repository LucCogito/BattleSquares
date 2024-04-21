using UnityEngine;

public abstract class Movement
{
    protected Rigidbody2D _rigidbody;
    protected float _maxSpeed, _maxSpeedSqr, _acceleration;

    public Movement(Rigidbody2D rigidbody) => _rigidbody = rigidbody;

    public abstract void Tick(Vector2 moveVector, float timeDelta);
}