using UnityEngine;
using TMPro;


public class Playermovement : MonoBehaviour
{
    Animator animator;

    public float forwardSpeed = 5f;
    public float maxSpeed = 15f;
    public float acceleration = 0.2f;
    public float sideSpeed = 15f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private int currentLane = 1; // 0 = Left, 1 = Middle, 2 = Right
    private float[] lanes = { -318.68f, -322.26f, -324.66f };
    public GameObject gameOverPanel;
    public TextMeshProUGUI coinText;
    private int coinCount = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += acceleration * Time.deltaTime;
        }
        // Move forward
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        animator.SetFloat("Speed", 1);

        // Change lane
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
        }

        // Move smoothly to the selected lane
        float targetX = lanes[currentLane];

        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(targetX, transform.position.y, transform.position.z),
            sideSpeed * Time.deltaTime
        );
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            coinText.text = "Score: " + coinCount;

            Destroy(other.gameObject);
        }
    }

}