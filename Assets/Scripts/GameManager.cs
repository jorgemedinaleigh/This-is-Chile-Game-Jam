using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float timer;
    private PlayerMovement playerMovement;

    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        timerText.text = timer.ToString();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        DisplayTime(timer);
        HandleGameOver();
    }

    private void DisplayTime(float timeToDisplay)
    {
        if(playerMovement.gameOver == false)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            float milliseconds = (timeToDisplay % 1) * 1000;

            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
    }

    private void HandleGameOver()
    {
        if(playerMovement.gameOver)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
