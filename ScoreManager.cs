using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Leaderboards leaderboards;

    [Header("LEVEL REFERENCE")]
    private readonly int[] levelUpExp = {5,7,10,15,20};
    public int currentLevel = 0;
    private int currentExp;
    public Image expProgress;


    [Header("SCORE REFERENCE")]
    public int score;
    public TextMeshProUGUI pointObject;
    public TextMeshProUGUI scoreText;
    
    private int[] highScores;
    private int scoreIndex = -1;
    private bool isNewHighScore;
    
    public void Awake()
    {
        scoreText.text = "Score " + 0;
        LeaderboardsData data = SaveSystem.LoadLeaderboards();
        highScores = data.highScores;
    }

    public void AddScore(int score)
    {
        pointObject.gameObject.SetActive(false);
        pointObject.gameObject.SetActive(true);
        pointObject.text = "+" + score;   

        this.score += score;
        scoreText.text = "SCORE " + this.score;

        if (currentLevel >= levelUpExp.Length)
        {
            expProgress.fillAmount = 1f;
        }
        else
        { 
            FillEXPUpdate();
        }
        SoundSystem.Instance.PlayPointSFX();
    }

    public void FillEXPUpdate()
    {
        currentExp++;
        expProgress.fillAmount = (float)currentExp / levelUpExp[currentLevel];

        if (currentExp >= levelUpExp[currentLevel])
        {
            currentLevel++;
            ResetEXPUpdate();
            StartCoroutine(playerMovement.AnimateSize(currentLevel + 1));
        }


    }

    public void ResetEXPUpdate()
    {
        currentExp = 0;
        expProgress.fillAmount = 0;
    }
    
    public void LoadLeaderboards()
    {
        for (int i = 0; i < highScores.Length; i++) {
            if (score > highScores[i]) {
                for (int j = highScores.Length - 1; i < j; j--) {
                    highScores[j] = highScores[j - 1];
                }

                highScores[i] = score;
                scoreIndex = i;
                isNewHighScore = true;

                break;
            }
        }

        SaveSystem.SaveScoreToLeaderboard(highScores);
        leaderboards.DisplayLeaderboardData(scoreIndex, score);
    }

}
