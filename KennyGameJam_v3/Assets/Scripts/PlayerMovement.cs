using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public Animator playerAnimations;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector3 originalScale;
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale; 
    }

    void Update()
    {
        
        
        // bla bla
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        playerAnimations.SetBool("IsJumping", !isGrounded);

        // Handle movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        // Ensure the player is facing the right direction
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        // Handle animations
        playerAnimations.SetBool("IsRuning", rb.velocity.x != 0);
    }

    
}
