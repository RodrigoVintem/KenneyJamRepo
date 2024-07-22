using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerScript : MonoBehaviour
{
    public PlayerMovement playerMove;


    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.layer == 8 || other.gameObject.CompareTag("Wall"))
        {
            playerMove.isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.layer == 8 || other.gameObject.CompareTag("Wall"))
        {
            playerMove.isGrounded = false;
        }
    }
}
