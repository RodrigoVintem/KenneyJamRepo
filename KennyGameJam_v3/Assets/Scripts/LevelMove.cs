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
            Destroy(other.gameObject);
            Destroy(Destric);
            print("Switching level to " + nextLevelIndex);
            SceneManager.LoadScene(nextLevelIndex, LoadSceneMode.Single);
        }
    }
}
