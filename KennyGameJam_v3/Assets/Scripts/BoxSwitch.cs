using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitch : MonoBehaviour
{
    public List<Transform> points;
    public Transform platform;
    int goalPoint = 0;
    public float moveSpeed = 2;
    public bool isActivated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
          isActivated = true;
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

       if(Vector2.Distance(platform.position, points[goalPoint].position) < 0.1f)
       {
           if(goalPoint == points.Count - 1){
               goalPoint = 0;
           }else{
               goalPoint++;
           }
       }
    }


}
