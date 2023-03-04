using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreItem : MonoBehaviour
{
    public TMP_Text rankText;
    public TMP_Text scoreText;

    public Color highLightColor;


    public void SetScore(int rank, int score)
    {
        rankText.text = rank.ToString();
        scoreText.text = score.ToString();
    }

    public void HighlightScore()
    {
        GetComponent<Image>().color = highLightColor;
    }
}
