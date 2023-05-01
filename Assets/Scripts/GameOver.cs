using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public Text gameOver;
    public ScoreManager score;
    public List<MonoBehaviour> scriptsToDisable;
    public float timeToReturn;
    string[] itemNames = { "Meat", "Bread", "Milk", "Takeaway", "Ice Cream", "Pizza", "Curry", "Groceries" };
    string countDown;
    bool dead=false;
    string outputText;
    float timer = 0;
    public void SetGameOver(string deathReason)
    {
        dead = true;
        outputText = "You died because " + deathReason + "\n";
        outputText += "You got a score of " + score.GetPoints().ToString() + "\n";
        foreach (MonoBehaviour script in scriptsToDisable)
        {
            script.enabled = false;
        }
        gameOver.text = outputText;

        PlayerPrefs.SetInt("highScore", Mathf.Max(PlayerPrefs.GetInt("highScore", 0), score.GetPoints()));
    }
    public void SetCountDownText(int num, int type)
    {
        countDown += "You have " + num.ToString() + " seconds left to collect " + itemNames[type];
    }
    private void LateUpdate()
    {
        if(!dead)
            gameOver.text = countDown;
        countDown = "";
        if(dead)
        {
            timer += Time.deltaTime;
            if(timer > timeToReturn)
            {
                SceneManager.LoadScene("menu");
            }
            gameOver.text = outputText + "\n Returning to menu in " + ((int)(timeToReturn - timer)).ToString() + " seconds";
        }
    }


}
