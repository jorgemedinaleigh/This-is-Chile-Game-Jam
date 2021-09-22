using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z - 7;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
