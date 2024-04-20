using UnityEngine;

public interface IInputSource
{
    Vector2 MoveVector { get; }

    void Tick();
}