using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitch : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    [SerializeField] Color ColorIsActive;
    public List<Transform> points;
    public Transform platform;
    int goalPoint = 0;
    public float moveSpeed = 2;
    public bool isActivated = false;

    private void Start() {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
          isActivated = true;
          spriteRender.color = ColorIsActive;
        }
    }

    private void Update()
    {
        if(isActivated){
            MoveToNextPoint();
        }   
    }

    void MoveToNextPoint()
    {
       platform.position = Vector2.MoveTowards(platform.position, points[goalPoint].position, moveSpeed * Time.deltaTime);
    }


}
