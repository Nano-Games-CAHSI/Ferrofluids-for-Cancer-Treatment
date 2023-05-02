using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float countdownTimeInSeconds = 60.0f;
    [SerializeField] private TextMeshProUGUI timerText;

    private float currentTimeInSeconds;
    private bool isCountingDown;

    private void Start()
    {
        currentTimeInSeconds = countdownTimeInSeconds;
        isCountingDown = true;
    }

    private void Update()
    {
        if (isCountingDown)
        {
            currentTimeInSeconds -= Time.deltaTime;
            DisplayTime(currentTimeInSeconds);

            if (currentTimeInSeconds <= 0)
            {
                currentTimeInSeconds = 0;
                isCountingDown = false;
                TimerEnded();
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void TimerEnded()
    {
        timerText.text = "Game Over!";
    }
}

