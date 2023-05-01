using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Highscore: " + PlayerPrefs.GetInt("highScore", 0).ToString();
    }
}