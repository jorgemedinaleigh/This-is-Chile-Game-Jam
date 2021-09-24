using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float bound = -15;

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.gameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        destroyOutOfBounds();
    }

    private void destroyOutOfBounds()
    {
        if(transform.position.z < bound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
