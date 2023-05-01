using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOver;
    public ScoreManager score;
    public List<MonoBehaviour> scriptsToDisable;
    string[] itemNames = { "Meat", "Bread", "Milk", "Takeaway", "Ice Cream", "Pizza", "Curry", "Groceries" };
    string countDown;
    bool dead=false;

    public void SetGameOver(string deathReason)
    {
        dead = true;
        string outputText = "You died because " + deathReason + "\n";
        outputText += "You got a score of " + score.ToString() + "\n";
        foreach (MonoBehaviour script in scriptsToDisable)
        {
            script.enabled = false;
        }
        gameOver.text = outputText;
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
    }


}
