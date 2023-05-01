using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBuilding : MonoBehaviour
{
    public int type;
    public int numPackages;
    public GeneratorManager manager;
    public StackPackages stacker;
    public GameOver gameOver;
    int maxPackages;
    float packageTimer;
    float timer=0;
    string[] itemNames = { "Meat", "Bread", "Milk", "Takeaway", "Ice Cream", "Pizza", "Curry", "Groceries" };
    // Start is called before the first frame update
    void Start()
    {
        manager.AddGenerator(this);
        maxPackages = manager.maxPackagesInOne;
        packageTimer = manager.maxPackagesTime;
    }
    public int Generate()
    {
        numPackages++;
        stacker.Stack(type);
        return type;
    }
    public int Suck()
    {
        if(numPackages<=0)
        {
            return -1;
        }
        numPackages--;
        return type;
    }

    // Update is called once per frame
    void Update()
    {
        if (numPackages > maxPackages)
        {
            timer += Time.deltaTime;
            gameOver.SetCountDownText((int)(packageTimer - timer), type);
            if (timer > packageTimer)
            {
                //we die here
                gameOver.SetGameOver("You didn't collect " + itemNames[type] + " in time :(");
            }
        }
        else
        {
            timer = 0;
        }
    }
}
