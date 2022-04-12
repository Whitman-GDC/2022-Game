using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Rigidbody2D enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2.0f, 2.0f);
    }


    void SpawnEnemy() {
        Instantiate(enemyPrefab, new Vector2(0, 0), transform.rotation, transform);
    }
}
