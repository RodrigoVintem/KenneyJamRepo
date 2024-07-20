using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitationBugFixing : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private bool HereWall = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag != "Player")
        {
            HereWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag != "Player")
        {
            HereWall = false;
        }
    }

    private void Update() {
        if(HereWall && playerMovement.rb.velocity.x != 0 && !playerMovement.isGrounded)
        {
            Debug.Log("asdf");
            Vector2 newVelocity = playerMovement.rb.velocity;
            newVelocity.x = 0;
            playerMovement.rb.velocity = newVelocity;
            Debug.Log(playerMovement.rb.velocity.x);
        }
    }

}
