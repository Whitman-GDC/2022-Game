using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate() {
        //Destroy projectile once offscreen
        if (transform.position.magnitude > 20) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Projectile Collision with " + other.gameObject); 
        
        // Destroy the projectile
        Destroy(gameObject);

        // If it hit an enemy, damage the enemy
        if(other.tag == "Enemy") {
            other.gameObject.GetComponent<EnemyStatus>().TakeDamage(100);
        }
    }
}
