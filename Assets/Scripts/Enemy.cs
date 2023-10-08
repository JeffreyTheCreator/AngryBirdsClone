using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 4f;
    public static int EnemiesAlive = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemiesAlive++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.relativeVelocity.magnitude > health)
        {
            Die();
        }

    }

    void Die()
    {
        EnemiesAlive--;
        Destroy(gameObject);
    }
    
}
