using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;  
    public Text scoreText;        

    void Start()
    {
        UpdateScoreDisplay();
    }
    public static void AddScore(int points)
    {
        score += points; 
    }

    void Update()
    {
        UpdateScoreDisplay();
    }
    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
