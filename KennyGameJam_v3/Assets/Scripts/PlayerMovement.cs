using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] AudioSource PlayerSounds;
    public Transform SpawnPoint;
    private static PlayerMovement instance;
    [SerializeField] GameObject Body;
    public Animator playerAnimations;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float fallSpeed = 10f; // New fall speed variable
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    public bool isGrounded;
    private Vector3 originalScale;
    private Queue<GameObject> spawnedBodies = new Queue<GameObject>();

    private void Awake()
    {
        transform.position = SpawnPoint.position;
        DontDestroyOnLoad(SpawnPoint.gameObject);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Ensure this GameObject persists
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        playerAnimations.SetBool("IsJumping", !isGrounded);

        // Handle movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        
        // Update the velocity based on platform interaction if needed

        rb.velocity = playerVelocity;

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PlayerSounds.Play(0);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // Ensure the player is facing the right direction
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        // Handle animations
        playerAnimations.SetBool("IsRuning", moveInput != 0);

        // Check for input to destroy all bodies
        if (Input.GetKeyDown(KeyCode.B))
        {
            DestroyAllBodies();
        }
    }

    public void SpawnBody()
    {
        // Instantiate a new body at the player's position
        GameObject spawnedBody = Instantiate(Body, transform.position, transform.rotation);
        DontDestroyOnLoad(spawnedBody);

        // Add the spawned body to the queue
        spawnedBodies.Enqueue(spawnedBody);

        Debug.Log("Bodies in queue: " + spawnedBodies.Count);

        // If there are more than 5 bodies, remove the oldest one
        if (spawnedBodies.Count > 5)
        {
            GameObject oldBody = spawnedBodies.Dequeue();
            Destroy(oldBody);
        }

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        transform.position = SpawnPoint.position;
    }

    private void DestroyAllBodies()
    {
        while (spawnedBodies.Count > 0)
        {
            GameObject body = spawnedBodies.Dequeue();
            Destroy(body);
        }
    }
}
