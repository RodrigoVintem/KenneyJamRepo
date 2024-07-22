using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int nextLevelIndex;
    public GameObject Destric;

    

    private void OnTriggerEnter2D(Collider2D other) {
        print("Triggered");

        if (other.tag == "Player")
        {
            DestroyAllDiethBodiesInScene();
            Destroy(other.gameObject);
            Destroy(Destric);
            print("Switching level to " + nextLevelIndex);
            SceneManager.LoadScene(nextLevelIndex, LoadSceneMode.Single);
        }
    }

    void DestroyAllDiethBodiesInScene()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "DiethBody(Clone)")
            {
                Destroy(obj);
            }
        }
    }
}
