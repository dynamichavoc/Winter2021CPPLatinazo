using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        COLLECTIBLE
    }

    public CollectibleType currentCollectible;
    public AudioClip collisionClip;
    AudioSource pickupAudio;
    BoxCollider2D trigger;

    private void Start()
    {
        trigger = GetComponent<BoxCollider2D>();
        pickupAudio = GetComponent<AudioSource>();
        if (pickupAudio)
        {
            pickupAudio.loop = false;
            pickupAudio.clip = collisionClip;
        }
    }

    private void Update()
    {
        if (!pickupAudio.isPlaying && !trigger.enabled)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currentCollectible)
            {
                case CollectibleType.POWERUP:
                    Debug.Log("PowerUp");
                    collision.GetComponent<playerMovement>().StartJumpForceChange();
                    Destroy(gameObject);
                    break;
                case CollectibleType.COLLECTIBLE:
                    Debug.Log("Collectible");
                    GameManager.instance.score++;
                    pickupAudio.Play();
                    trigger.enabled = false;
                    break;
            }
        }
    }
}
