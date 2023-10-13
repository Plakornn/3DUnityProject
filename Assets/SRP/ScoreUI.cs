using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;
    private int score; 

    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0); 
        scoreText.text = "Score: " + score;
    }

    void UpdateScore(int newScore)
    {
        score = newScore; 

        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();

        scoreText.text = "Score: " + score;
    }
}
