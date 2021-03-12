using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class playerFire : MonoBehaviour
{
    SpriteRenderer marioSprite;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float projectileSpeed;
    public Projectile projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        marioSprite = GetComponent<SpriteRenderer>();

        if (projectileSpeed <= 0)
            projectileSpeed = 7.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Unity Inpector Values Not Set");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasManager.GameIsPaused == false)
        {
            if (Input.GetButtonDown("Fire1"))
                FireProjectile();
        }
    }

    void FireProjectile()
    {
        if (marioSprite.flipX)
        {
            Debug.Log("Fire Left Side");
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            projectileInstance.transform.localScale = new Vector3(-projectileInstance.transform.localScale.x, projectileInstance.transform.localScale.y, projectileInstance.transform.localScale.z);
            projectileInstance.speed = 0 - projectileSpeed;
            

        }
        else
        {
            Debug.Log("Fire Right Side");
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            projectileInstance.speed = projectileSpeed;
        }

    }
}
