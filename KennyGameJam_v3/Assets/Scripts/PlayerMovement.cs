using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnimations;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Handle movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(rb.velocity.x > 0)
        {
            transform.Rotate(0, 0, 0);
        }
        if(rb.velocity.x < 0)
        {
            transform.Rotate(0, -180, 0);
        }
        if(rb.velocity.x != 0)
        {
            playerAnimations.SetBool("IsRuning", true);
        }
        else if(rb.velocity.x == 0)
        {
            playerAnimations.SetBool("IsRuning", false);
        }
    }
}
