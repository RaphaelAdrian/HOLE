using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("GAME OVER REFERENCE")]
    public bool isGameOver;
    public GameObject leaderboardsPanel;
    public ScoreManager scoreManager;

    
    [Header("TIMER")]
    public CountDownTimer timer;
    public float timeValue;

    public void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        StartTimer();
    }

    

    public void GameOver()
    {
        isGameOver = true;
        scoreManager.LoadLeaderboards();
        Time.timeScale = 0;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void StartTimer()
    {
        Time.timeScale = 1;
        timer.SetTime(timeValue);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
