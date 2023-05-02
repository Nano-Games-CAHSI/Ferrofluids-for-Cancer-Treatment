using System.Collections;
using TMPro;
using UnityEngine;

public class CountUpTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTimeinSeconds;

    void Start()
    {
        elapsedTimeinSeconds = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTimeinSeconds += Time.deltaTime;
        DisplayTime(elapsedTimeinSeconds);
        
    }

    public float GetElapsedTime()
    {
        return elapsedTimeinSeconds;
    }

    private void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = (timeToDisplay % 1) * 1000;
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
