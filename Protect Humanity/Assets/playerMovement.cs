using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    float speedX, speedY;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // Input
        speedX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movementSpeed;

        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}
