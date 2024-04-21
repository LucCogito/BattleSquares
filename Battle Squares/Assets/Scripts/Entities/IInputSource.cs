using UnityEngine;

public interface IInputSource
{
    Vector2 MoveVector { get; }
    bool IsAbility1Performed { get; }
    bool IsAbility2Performed { get; }
    public Vector2 AimPositon { get; }

    void Tick();
}