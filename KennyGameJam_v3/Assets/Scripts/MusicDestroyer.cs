using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDestroyer : MonoBehaviour
{
    public LevelMove moveLevel;
    private GameObject DestoryObject;
    // Start is called before the first frame update
    void Start()
    {
        DestoryObject = GameObject.Find("Music");
        moveLevel.Destric = DestoryObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
