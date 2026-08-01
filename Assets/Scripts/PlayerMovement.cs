using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float forwardSpeed = 8f;
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;

    [Header("Jump")]
    public float jumpForce = 7f;

    private Rigidbody rb;
    private int currentLane = 1; // 0 = Left, 1 = Center, 2 = Right
    private bool isGrounded = true;
    private bool gameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gameOver)
            return;

        // Move forward
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Move Left
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && currentLane > 0)
            currentLane--;

        // Move Right
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && currentLane < 2)
            currentLane++;

        // Jump
        if ((Input.GetKeyDown(KeyCode.UpArrow) ||
             Input.GetKeyDown(KeyCode.W) ||
             Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Smooth lane movement
        Vector3 targetPosition = transform.position;
        targetPosition.x = (currentLane - 1) * laneDistance;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            laneChangeSpeed * Time.deltaTime
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;

        forwardSpeed = 0f;
        laneChangeSpeed = 0f;

        rb.linearVelocity = Vector3.zero;

        Debug.Log("GAME OVER!");
    }
}