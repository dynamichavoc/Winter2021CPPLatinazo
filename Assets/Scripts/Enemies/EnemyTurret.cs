using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyTurret : MonoBehaviour
{
    AudioSource deathAudio;
    public AudioClip deathSound;

    public Transform projectileSpawnPoint;
    public Transform projectileSpawnRight;
    public Projectile projectilePrefab;
    public Transform playerPos;
    public Vector2 playerDirection;

    public float projectileForce;

    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;
    public int health;

    Animator anim;
    SpriteRenderer turretSprite;
    // Start is called before the first frame update
    void Start()
    {
        deathAudio = gameObject.AddComponent<AudioSource>();
        deathAudio.clip = deathSound;
        deathAudio.loop = false;
        anim = GetComponent<Animator>();
        turretSprite = GetComponent<SpriteRenderer>();

        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
        }

        if (health <= 0)
        {
            health = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = transform.position - playerPos.position;
        if (playerDirection.x > 0 && turretSprite.flipX || playerDirection.x < 0 && !turretSprite.flipX)
        {
            turretSprite.flipX = !turretSprite.flipX;
        }
        if (!turretSprite.flipX)
        {
            float distanceToPlayer = Vector3.Distance(playerPos.position, transform.position);
            if (distanceToPlayer < 5.8)
            {
                if (Time.time >= timeSinceLastFire + projectileFireRate)
                {
                    anim.SetBool("Fire", true);
                    timeSinceLastFire = Time.time;
                }
            }
        }
        else
        {
            float distanceToPlayer = Vector3.Distance(playerPos.position, transform.position);
            if (distanceToPlayer < 5.8)
            {
                if (Time.time >= timeSinceLastFire + projectileFireRate)
                {
                    anim.SetBool("FireRight", true);
                    timeSinceLastFire = Time.time;
                }
            }
        }

    }

    public void Fire()
    {
        Projectile temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        temp.speed = -projectileForce;
    }

    public void FireFlip()
    {
        Projectile temp = Instantiate(projectilePrefab, projectileSpawnRight.position, projectileSpawnRight.rotation);
        temp.speed = projectileForce;
    }

    public void returnToIdle()
    {
        anim.SetBool("Fire", false);
        anim.SetBool("FireRight", false);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        (if (collision.gameObject.tag == "PlayerProjectile")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }*/

    public void isDead()
    {
        health--;
        if (health <= 0)
        {
            anim.SetBool("Death", true);
            deathAudio.Play();
        }
    }

    public void FinishedDeath()
    {
        Destroy(gameObject, 2.0f);
    }
}
