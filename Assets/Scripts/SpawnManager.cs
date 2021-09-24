using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] float minRepeatRate = 1f;
    [SerializeField] float maxRepeatRate = 5f;

    private Vector3 spawnPos;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if(waitTime <= 0)
        {
            SpawnObstacle();
            SetTimer();
        }
    }

    private void SpawnObstacle()
    {
        float range = 4.5f;
        float xPos = Random.Range(-range, range);
        spawnPos = new Vector3(xPos, 0, 30);

        int randomIndex = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[randomIndex], spawnPos, obstacles[randomIndex].transform.rotation);
    }

    private void SetTimer()
    {
        waitTime = Random.Range(minRepeatRate, maxRepeatRate);
    }
}
