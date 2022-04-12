using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public enum MovementType {Random, Reflect, Follow, Orbit};
    public MovementType type;
    public float moveSpeed;
    public float timeout;
    private float horizontal;
    private float vertical;
    private bool isTouching;

    void Start()
    {
        isTouching = false;
        horizontal = 0.0f;
        vertical = 0.0f;

        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(horizontal, vertical);

        // Sets the initial movement states, changes movement every interval seconds. 
        if (type == MovementType.Random)    // This works but collider is twitchy
        {
            InvokeRepeating("RandomMovement", 0.0f, timeout);
        }
    }

    private void Update()
    {
        if(type != MovementType.Random)
        {
            CancelInvoke("RandomMovement");
        }
    }

    private void FixedUpdate()
    {
        if(isTouching && type == MovementType.Random)
        {
            RandomMovement();
        } 
        else if (type == MovementType.Follow)   // Works Perfectly
        {
            FollowMovement();
        } 
        else if(type == MovementType.Orbit)
        {
            OrbitMovement();
        }

        Vector2 movementDirection = new Vector2(horizontal, vertical);

        movementDirection.Normalize();
        movementDirection *= moveSpeed;

        rb.velocity = movementDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouching = true;
        if(type == MovementType.Reflect)
        {
            ReflectMovement(collision);
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouching = false;
    }

    private void RandomMovement()
    {
        horizontal = Random.Range(-1.0f, 1.0f);
        vertical = Random.Range(-1.0f, 1.0f);
    }

    private void ReflectMovement(Collision2D collision) 
    {
        Vector2 newDirection = Vector2.Reflect(rb.velocity, collision.GetContact(0).normal);
        horizontal = newDirection.x;
        vertical = newDirection.y;
    }

    private void FollowMovement()
    {
        Transform player = GameObject.Find("Player").GetComponent<Transform>();
        horizontal = player.position.x - transform.position.x;
        vertical = player.position.y - transform.position.y;
    }

    private void OrbitMovement()
    {

    }

}