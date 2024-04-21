using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAbility : Ability
{
    public override void Cast(Transform casterTransform, Vector2 targetPosition)
    {
        new GameObject().AddComponent<Projectile>();
    }
}
