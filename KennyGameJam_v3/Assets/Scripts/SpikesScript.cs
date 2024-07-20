using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerMovement PlayerCollision = other.gameObject.GetComponent<PlayerMovement>();
            PlayerCollision.SpawnBody();
        }
    }
}
