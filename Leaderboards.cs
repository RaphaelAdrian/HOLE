using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboards : MonoBehaviour
{
    public ScoreItem scoreItemprefab;
    public Transform leaderboardItemsRoot;
    public Transform leaderboardPanel;
    public TMP_Text currentScoreText;

    public Button retryButton;
    public Button quitButton;
    // Start is called before the first frame update
    public void DisplayLeaderboardData(int scoreIndex, int currentScore)
    {
        LeaderboardsData data = SaveSystem.LoadLeaderboards();
        currentScoreText.text = currentScore.ToString();

        // Populate leaderboards data
        for (int i = 0; i < data.highScores.Length; i++)
        {
            ScoreItem scoreItem = Instantiate(scoreItemprefab, leaderboardItemsRoot);
            scoreItem.SetScore(i + 1, data.highScores[i]);
            if (scoreIndex == i)
            {
                scoreItem.HighlightScore();
            }
        }
        
        leaderboardPanel.gameObject.SetActive(true);
    }

    public void Awake()
    {
        // Map quit button and retry button
        retryButton.onClick.AddListener(() =>
        {
            GameManager.instance.RestartGame();
        });
        quitButton.onClick.AddListener(() =>
        {
            GameManager.instance.Exit();
        });
    }
}
