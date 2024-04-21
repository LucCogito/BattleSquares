using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests
{
    [UnityTest]
    public IEnumerator Player_ForHorizontalInput_MovesAlongAxisX()
    {
        var player = new GameObject().AddComponent<Player>();
        var rigidbody = player.gameObject.AddComponent<Rigidbody2D>();
        player.SetTestRigidbody(rigidbody);
        player.SetTestParameters(10f, 100f);
        var input = Substitute.For<IInputSource>();
        input.MoveVector.Returns(Vector2.right);
        player.SetTestInputSource(input);

        yield return new WaitForFixedUpdate();

        Assert.Greater(player.transform.position.x, 0f);

        GameObject.Destroy(player.gameObject);
    }

    [UnityTest]
    public IEnumerator Player_ForVerticalInput_MovesAlongAxisY()
    {
        var player = new GameObject().AddComponent<Player>();
        var rigidbody = player.gameObject.AddComponent<Rigidbody2D>();
        player.SetTestRigidbody(rigidbody);
        player.SetTestParameters(10f, 100f);
        var input = Substitute.For<IInputSource>();
        input.MoveVector.Returns(Vector2.up);
        player.SetTestInputSource(input);

        yield return new WaitForFixedUpdate();

        Assert.Greater(player.transform.position.y, 0f);

        GameObject.Destroy(player.gameObject);
    }
}
