using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitch : MonoBehaviour
{
    //If the Player hits this object, then a platform will start moving

    public GameObject platform;
    public float speed = 1.0f;
    public bool isMoving = false;
    public Vector3 targetPosition;
    public Vector3 startPosition;

    void Start()
    {
        startPosition = platform.transform.position;
        targetPosition = new Vector3(startPosition.x, startPosition.y + 5, startPosition.z);
    }

    void Update()
    {
        if (isMoving)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, startPosition, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isMoving = true;
        }
    }

}
