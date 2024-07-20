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
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector3 originalScale;
    private Queue<GameObject> spawnedBodies = new Queue<GameObject>();
    private Transform currentPlatform;
    private Vector3 previousPlatformPosition;

    private void Awake()
    {
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
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PlayerSounds.Play(0);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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

        // Update player position if on a moving platform
        if (currentPlatform != null)
        {
            Vector3 platformMovement = currentPlatform.position - previousPlatformPosition;
            transform.position += platformMovement;
            previousPlatformPosition = currentPlatform.position;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            currentPlatform = other.transform;
            previousPlatformPosition = currentPlatform.position;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            currentPlatform = null;
        }
    }
}
