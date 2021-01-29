using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

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
        Debug.Log("groundCheck does not exist, please set a transform value for groundCheck")
    }

// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);


        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }
}
