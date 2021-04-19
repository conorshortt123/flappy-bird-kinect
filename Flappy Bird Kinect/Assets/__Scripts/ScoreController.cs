using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score;
    private float increment = 1;

    public void SetScore(float score)
    {
        this.score = score;
    }

    public float GetScore()
    {
        return score;
    }

    public void IncrementScore()
    {
        score += increment;
        scoreText.text = ((int)score).ToString();
    }
}
