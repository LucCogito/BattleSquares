using System;
using UnityEngine;

[Serializable]
public class Ability
{
    [SerializeField]
    protected Projectile _projectilePrefab;
    [SerializeField]
    protected float _cooldown;

    public float CurrentCooldown { get; private set; }

    public virtual void Cast(Transform casterTransform, Vector2 targetPosition)
    {
        GameObject.Instantiate(_projectilePrefab, casterTransform.position, Quaternion.identity);
        CurrentCooldown = Time.time + _cooldown;
    }
}