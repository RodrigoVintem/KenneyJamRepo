using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Vector3 currentTarget;

    void Start()
    {
        // Set the initial target to Point A
        currentTarget = pointA.position;
    }

    void Update()
    {
        // Move the enemy towards the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        // Check if the enemy has reached the target
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            // Switch target to the other point
            if (currentTarget == pointA.position)
            {
                currentTarget = pointB.position;
            }
            else
            {
                currentTarget = pointA.position;
            }
        }
    }
}
