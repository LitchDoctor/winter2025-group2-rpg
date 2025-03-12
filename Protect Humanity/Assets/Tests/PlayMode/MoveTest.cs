using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Reflection;

public class MoveTest
{
    [UnityTest]
    public IEnumerator MoveNorth()
    {
        // Arrange
        GameObject player = new GameObject();
        Rigidbody2D rb = player.AddComponent<Rigidbody2D>();
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;
        rb.gravityScale = 0f;
        PlayerMovement movement = player.AddComponent<PlayerMovement>();
        movement.speed = 5f;

        yield return null;

        FieldInfo inputField = typeof(PlayerMovement).GetField("input", BindingFlags.NonPublic | BindingFlags.Instance);
        inputField.SetValue(movement, new Vector2(0, 1));

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(new Vector2(0, 5f), rb.linearVelocity);

        Object.Destroy(player);
    }
    [UnityTest]
    public IEnumerator MoveSouth()
    {
        // Arrange
        GameObject player = new GameObject();
        Rigidbody2D rb = player.AddComponent<Rigidbody2D>();
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;
        rb.gravityScale = 0f;
        PlayerMovement movement = player.AddComponent<PlayerMovement>();
        movement.speed = 5f;

        yield return null;

        FieldInfo inputField = typeof(PlayerMovement).GetField("input", BindingFlags.NonPublic | BindingFlags.Instance);
        inputField.SetValue(movement, new Vector2(0, -1));

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(new Vector2(0, -5f), rb.linearVelocity);

        Object.Destroy(player);
    }
    [UnityTest]
    public IEnumerator MoveWest()
    {
        // Arrange
        GameObject player = new GameObject();
        Rigidbody2D rb = player.AddComponent<Rigidbody2D>();
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;
        rb.gravityScale = 0f;
        PlayerMovement movement = player.AddComponent<PlayerMovement>();
        movement.speed = 5f;

        yield return null;

        FieldInfo inputField = typeof(PlayerMovement).GetField("input", BindingFlags.NonPublic | BindingFlags.Instance);
        inputField.SetValue(movement, new Vector2(-1, 0));

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(new Vector2(-5f, 0f), rb.linearVelocity);

        Object.Destroy(player);
    }
    [UnityTest]
    public IEnumerator MoveEast()
    {
        // Arrange
        GameObject player = new GameObject();
        Rigidbody2D rb = player.AddComponent<Rigidbody2D>();
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;
        rb.gravityScale = 0f;
        PlayerMovement movement = player.AddComponent<PlayerMovement>();
        movement.speed = 5f;

        yield return null;

        FieldInfo inputField = typeof(PlayerMovement).GetField("input", BindingFlags.NonPublic | BindingFlags.Instance);
        inputField.SetValue(movement, new Vector2(1, 0));

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(new Vector2(5f, 0f), rb.linearVelocity);

        Object.Destroy(player);
    }
    [UnityTest]
    public IEnumerator NorthEast()
    {
        // Arrange
        GameObject player = new GameObject();
        Rigidbody2D rb = player.AddComponent<Rigidbody2D>();
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;
        rb.gravityScale = 0f;
        PlayerMovement movement = player.AddComponent<PlayerMovement>();
        movement.speed = 5f;

        yield return null;

        FieldInfo inputField = typeof(PlayerMovement).GetField("input", BindingFlags.NonPublic | BindingFlags.Instance);
        inputField.SetValue(movement, new Vector2(1, 1));

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(new Vector2(5f, 5f), rb.linearVelocity);

        Object.Destroy(player);
    }
}