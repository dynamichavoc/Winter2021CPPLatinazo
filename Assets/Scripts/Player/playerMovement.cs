using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer marioSprite;
    AudioSource jumpAudioSource;


    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public AudioClip jumpSFX;

    int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("Current Score Is " + _score);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        marioSprite = GetComponent<SpriteRenderer>();

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 100;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.01f;
        }

        if (!groundCheck)
        {
            Debug.Log("Groundcheck does not exist, please set a transform value for groundcheck");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasManager.GameIsPaused == false)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);
                if (!jumpAudioSource)
                {
                    jumpAudioSource = gameObject.AddComponent<AudioSource>();
                    jumpAudioSource.clip = jumpSFX;
                    jumpAudioSource.loop = false;
                    jumpAudioSource.Play();
                }
                else
                {
                    jumpAudioSource.Play();
                }
            }

            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("isShooting", true);
            }

            if (Input.GetButtonUp("Fire1"))
            {
                anim.SetBool("isShooting", false);
            }

            if (Input.GetButtonDown("Jump") && verticalInput > 0)
            {
                anim.SetBool("isFlip", true);
            }

            if (verticalInput == 0)
            {
                anim.SetBool("isFlip", false);
            }

            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
            anim.SetFloat("speed", Mathf.Abs(horizontalInput));
            anim.SetBool("isGrounded", isGrounded);

            if (marioSprite.flipX && horizontalInput > 0 || !marioSprite.flipX && horizontalInput < 0)
                marioSprite.flipX = !marioSprite.flipX;
        }
    }

    public void StartJumpForceChange()
    {
        StartCoroutine(JumpForceChange());
    }

    IEnumerator JumpForceChange()
    {
        jumpForce = 600;
        yield return new WaitForSeconds(10.0f);
        jumpForce = 450;
    }
}
