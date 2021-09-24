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
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource audioPlayer;

    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
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
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            audioPlayer.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            dirtParticle.Stop();
            gameOver = true;
            explosionParticle.Play();
            audioPlayer.PlayOneShot(crashSound);
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
