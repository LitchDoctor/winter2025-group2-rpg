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

        movement.setAsTest();
        movement.setInput(0, 1);

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

        movement.setAsTest();
        movement.setInput(0, -1);

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

        movement.setAsTest();
        movement.setInput(-1, 0);

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

        movement.setAsTest();
        movement.setInput(1, 0);

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

        movement.setAsTest();
        movement.setInput(1f, 1f);

        yield return null;


        yield return new WaitForFixedUpdate();
        float componentSpeed = 5f/2f*Mathf.Sqrt(2f);
        
        Assert.AreEqual(new Vector2(componentSpeed, componentSpeed), rb.linearVelocity);

        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator NorthWest()
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

        movement.setAsTest();
        movement.setInput(-1f, 1f);

        yield return null;


        yield return new WaitForFixedUpdate();
        float componentSpeed = 5f/2f*Mathf.Sqrt(2f);
        
        Assert.AreEqual(new Vector2(-componentSpeed, componentSpeed), rb.linearVelocity);

        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator SouthEast()
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

        movement.setAsTest();
        movement.setInput(1f, -1f);

        yield return null;


        yield return new WaitForFixedUpdate();
        float componentSpeed = 5f/2f*Mathf.Sqrt(2f);
        
        Assert.AreEqual(new Vector2(componentSpeed, -componentSpeed), rb.linearVelocity);

        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator SouthWest()
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

        movement.setAsTest();
        movement.setInput(-1f, -1f);

        yield return null;


        yield return new WaitForFixedUpdate();
        float componentSpeed = 5f/2f*Mathf.Sqrt(2f);
        
        Assert.AreEqual(new Vector2(-componentSpeed, -componentSpeed), rb.linearVelocity);

        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator MoveNowhere()
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

        movement.setAsTest();
        movement.setInput(0, 0);

        yield return null;


        yield return new WaitForFixedUpdate();
        
        Assert.AreEqual(new Vector2(0, 0), rb.linearVelocity);

        Object.Destroy(player);
    }

}