using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public enum MovementType {Random, Reflect, Follow, Orbit};
    public MovementType type;
    public float moveSpeed = 20.0f;
    public float horizontal = 50.0f;
    public float vertical = 100.0f;
    public float timeout = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        type = MovementType.Random;
        transform.position = new Vector2(horizontal, vertical);
    }

    void Update()
    { 
        if(type == MovementType.Random)
        {
            InvokeRepeating("RandomMovement", 0.0f, timeout);
        } 
        else if(type == MovementType.Follow)
        {
            InvokeRepeating("FollowMovement", 0.0f, 0.0f);
        }
        else if(type == MovementType.Orbit)
        {

        }
    }

    private void FixedUpdate()
    {
        Vector2 movementDirection = new Vector2(horizontal, vertical);

        movementDirection.Normalize();
        movementDirection *= moveSpeed;

        rb.velocity = movementDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(type == MovementType.Reflect)
        {
            ReflectMovement(collision);
        }
    }

    private void RandomMovement()
    {
        horizontal = Random.Range(-1, 1);
        vertical = Random.Range(-1, 1);
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
        horizontal = player.position.x - horizontal;
        vertical = player.position.y - vertical;
    }

    private void Orbit()
    {

    }
}