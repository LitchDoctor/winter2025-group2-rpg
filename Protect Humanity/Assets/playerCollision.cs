using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log(message: "Colided with" + collisionInfo.gameObject);
        }
    }
}
