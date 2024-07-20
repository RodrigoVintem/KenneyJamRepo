using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
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
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnBody();
        }
        
        // bla bla
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        playerAnimations.SetBool("IsJumping", !isGrounded);

        // Handle movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        // Ensure the player is facing the right direction
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        // Handle animations
        playerAnimations.SetBool("IsRuning", rb.velocity.x != 0);
    }

    public void SpawnBody()
    {
        // Instantiate a new body at the player's position
        GameObject spawnedBody = Instantiate(Body, transform.position, transform.rotation);
        DontDestroyOnLoad(spawnedBody);

        // Add the spawned body to the queue
        spawnedBodies.Enqueue(spawnedBody);

        Debug.Log(spawnedBodies);

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
}
