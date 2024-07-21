using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitationBugFixing : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private bool isTouchingWall = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall")) // Ensure the wall objects have the "Wall" tag
        {
            isTouchingWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            isTouchingWall = false;
        }
    }

    private void Update()
    {
        if (isTouchingWall && !playerMovement.isGrounded)
        {
            // Stop horizontal movement
            Vector2 velocity = playerMovement.rb.velocity;
            if (Mathf.Abs(velocity.x) > 0)
            {
                playerMovement.moveSpeed = 0f;
            }
        }
        else 
        {
            playerMovement.moveSpeed = 5f;
        }
    }
}
