using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Vector3 offset = new Vector3(0, 1, -10);
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void Awake() {
      target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 targetPosition = target.position + offset;
      transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);      
    }
}
