using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D collision) 
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyWalker>().isDead();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "EnemyTurret")
        {
            collision.gameObject.GetComponent<EnemyTurret>().isDead();
            Destroy(gameObject);
        }
        /*if (collision.gameObject.tag == "EnemyProjectile")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }*/
    }
}
