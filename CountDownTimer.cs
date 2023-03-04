using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timeValue;
    private float timeCountDown;
    public bool isTimerDone;

    public UnityEvent eventAction;

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float minutes = Mathf.FloorToInt(timeToDisplay / 60) % 60;

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); ;
    }

    public void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
                isTimerDone = false;
            }
            else
            {
                timeValue = 0;
            }
            if (timeValue == 0)
            {
                isTimerDone = true;
                eventAction.Invoke();
            }
            DisplayTime(timeValue);
        }
    }

    public float SetTime(float seconds)
    {
        timeValue = seconds;
        return timeValue;
    }
}
