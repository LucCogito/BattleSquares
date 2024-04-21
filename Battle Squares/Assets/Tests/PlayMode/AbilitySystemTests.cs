using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AbilitySystemTests
{
    [UnityTest]
    public IEnumerator Tick_OnAbility1Action_CreatesOneProjectile()
    {
        var abilitySystem = new GameObject().AddComponent<AbilitySystem>();
        var input = Substitute.For<IInputSource>();
        input.IsAbility1Performed.Returns(true);
        abilitySystem.SetTestInputSource(input);
        abilitySystem.SetTestAbilitySlots(new TestAbility());

        abilitySystem.Tick();
        yield return null;

        var projectiles = GameObject.FindObjectsOfType<Projectile>();
        Assert.AreEqual(projectiles.Length, 1);

        foreach (var projectile in projectiles)
            GameObject.Destroy(projectile.gameObject);
        GameObject.Destroy(abilitySystem.gameObject);
    }

    [UnityTest]
    public IEnumerator Tick_OnAbility2Action_CreatesOneProjectile()
    {
        var abilitySystem = new GameObject().AddComponent<AbilitySystem>();
        var input = Substitute.For<IInputSource>();
        input.IsAbility2Performed.Returns(true);
        abilitySystem.SetTestInputSource(input);
        abilitySystem.SetTestAbilitySlots(new TestAbility());

        abilitySystem.Tick();
        yield return null;

        var projectiles = GameObject.FindObjectsOfType<Projectile>();
        Assert.AreEqual(projectiles.Length, 1);

        foreach (var projectile in projectiles)
            GameObject.Destroy(projectile.gameObject);
        GameObject.Destroy(abilitySystem.gameObject);
    }
}
