using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Points: " + score.ToString();
    }

    void Update()
    {
        scoreText.text = "Points: " + score.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = "Points: " + score.ToString();
    }

    public int GetPoints()
    {
        return score;
    }

    public void setPoints(int amount)
    {
        score = amount;
    }
}
