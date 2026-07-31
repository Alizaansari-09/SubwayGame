using UnityEngine;

public class Playermovement : MonoBehaviour
{
    Animator animator;

    public float forwardSpeed = 5f;
    public float sideSpeed = 25f;
    public float jumpForce = 7f;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move forward
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        animator.SetFloat("Speed", 1);

        // Move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * sideSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * sideSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}