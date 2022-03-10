using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        Vector2 movementDirection = new Vector2(horizontal, vertical);

        // Limit movement to the correct speed, even when moving diagonal
        movementDirection.Normalize();
        movementDirection *= runSpeed;

        rb.velocity = movementDirection;
    }
}
