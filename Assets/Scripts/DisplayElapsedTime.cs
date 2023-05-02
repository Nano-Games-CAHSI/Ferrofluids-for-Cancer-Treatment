using UnityEngine;
using TMPro;

public class DisplayElapsedTime : MonoBehaviour
{
    public TextMeshProUGUI elapsedTimeText;

    void Start()
    {
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", -1f);
        if (elapsedTime != -1f) // If elapsed time is available, format and display it.
        {
            DisplayTime(elapsedTime);
        }
        else // If elapsed time is not available, display an error message or an alternate text.
        {
            elapsedTimeText.text = "Error: Time data not found.";
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = (timeToDisplay % 1) * 1000;
        elapsedTimeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
