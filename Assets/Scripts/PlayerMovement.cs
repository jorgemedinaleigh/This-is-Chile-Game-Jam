using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float vertical;
    float range = 4.5f;
    bool isOnGround = true;
    public bool gameOver = false;

    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessJump();
        PreventAirMovement();
    }

    private void ProcessMovement()
    {
        vertical = -Input.GetAxisRaw("Vertical");

        float xOffset = vertical * Time.deltaTime * movementSpeed;
        float xPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(xPos, -range, range);

        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void ProcessJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }
    }

    private void PreventAirMovement()
    {
        if(isOnGround)
        {
            ProcessMovement();
        }
    }
}
