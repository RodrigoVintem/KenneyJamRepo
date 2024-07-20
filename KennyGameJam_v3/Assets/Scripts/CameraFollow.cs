using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Vector3 offset = new Vector3(0, 3, -10);
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
      target = GameObject.Find("Player").transform;
      Vector3 targetPosition = target.position + offset;
      transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);      
    }
}
