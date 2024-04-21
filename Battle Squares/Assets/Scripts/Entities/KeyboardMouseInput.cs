using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMouseInput : IInputSource
{
    public Vector2 MoveVector {get; private set;}
    public bool IsAbility1Performed => InputManager.instance.IsAbility1Performed;
    public bool IsAbility2Performed => InputManager.instance.IsAbility2Performed;
    public Vector2 AimPositon => InputManager.instance.MousePositon;

    public void Tick()
    {
        MoveVector = InputManager.instance.MoveActionVector;
    }
}
