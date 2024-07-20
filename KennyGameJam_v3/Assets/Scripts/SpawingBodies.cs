using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawingBodies : MonoBehaviour
{

    private static SpawingBodies instance;
    private Queue<GameObject> spawnedBodies = new Queue<GameObject>();
    [SerializeField] GameObject Body;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnBody();
        }
    }

    public void SpawnBody()
    {
        // Instantiate a new body at the player's position
        GameObject spawnedBody = Instantiate(Body, transform.position, transform.rotation);

        // Add the spawned body to the queue
        spawnedBodies.Enqueue(spawnedBody);

        Debug.Log("Bodies in queue: " + spawnedBodies.Count);

        // If there are more than 5 bodies, remove the oldest one
        if (spawnedBodies.Count > 5)
        {
            GameObject oldBody = spawnedBodies.Dequeue();
            Destroy(oldBody);
        }
        DontDestroyOnLoad(spawnedBody);

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
