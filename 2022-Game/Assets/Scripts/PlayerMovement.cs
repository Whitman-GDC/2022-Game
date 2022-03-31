using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal;
    float vertical;

    public Rigidbody2D projectilePrefab;
    public float projectileSpeed = 500;
    public float attackSpeed = 0.5f;
    public float coolDown;

    public float runSpeed = 20.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coolDown = Time.time;
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if(Input.GetMouseButton(0) && Time.time > coolDown) {
            FireProjectile();
        };
    }

    void FixedUpdate()
    {
        Vector2 movementDirection = new Vector2(horizontal, vertical);

        // Limit movement to the correct speed, even when moving diagonal
        movementDirection.Normalize();
        movementDirection *= runSpeed;

        rb.velocity = movementDirection;
    }

    void FireProjectile()
    {
        coolDown = Time.time + attackSpeed;

        // Get position of mouse, then subtract the players position to find the direction for the shot to move in
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)(worldMousePos - transform.position);
        direction.Normalize();

        // Make new projectile and shoot it in target direction (towards mouse)
        Rigidbody2D projectile = Instantiate(projectilePrefab, transform.position, transform.rotation) as Rigidbody2D;
       
        projectile.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);    

        
    }


}
