using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMouseInput : IInputSource
{
    public Vector2 MoveVector {get; private set;}

    public void Tick()
    {
        MoveVector = InputManager.instance.MoveActionVector;
    }
}
