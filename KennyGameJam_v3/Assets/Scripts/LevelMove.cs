using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int nextLevelIndex;

    public static LevelMove instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print("Triggered");

        if (other.tag == "Player")
        {
            print("Switching level to " + nextLevelIndex);
            SceneManager.LoadScene(nextLevelIndex, LoadSceneMode.Single);
        }
    }
}
