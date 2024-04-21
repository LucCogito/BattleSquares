using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTests
{
    [UnityTest]
    public IEnumerator EightDirectionMovement_ForHorizontalInput_MovesAlongAxisX()
    {
        var rigidbody = new GameObject().AddComponent<Rigidbody2D>();
        var movement = new EightDirectionMovement(rigidbody, 100, 10);

        movement.Tick(Vector2.right, .1f);
        yield return new WaitForFixedUpdate();

        Assert.Greater(rigidbody.transform.position.x, 0f);

        GameObject.Destroy(rigidbody.gameObject);
    }

    [UnityTest]
    public IEnumerator EightDirectionMovement_ForVerticalInput_MovesAlongAxisY()
    {
        var rigidbody = new GameObject().AddComponent<Rigidbody2D>();
        var movement = new EightDirectionMovement(rigidbody, 100, 10);

        movement.Tick(Vector2.up, .1f);
        yield return new WaitForFixedUpdate();

        Assert.Greater(rigidbody.transform.position.y, 0f);

        GameObject.Destroy(rigidbody.gameObject);
    }
}
