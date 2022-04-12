using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float hp = 100f;

    void Start() {
        
    }

    void Update() {
        
    }

    public void TakeDamage(float damage) {
        hp -= damage;

        if(hp <= 0) {
            Destroy(gameObject);
        }
    }
}
