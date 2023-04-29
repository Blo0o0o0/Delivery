using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBuilding : MonoBehaviour
{
    public int type;
    public int numPackages;
    GeneratorManager manager;
    int maxPackages;
    float packageTimer;
    float timer=0;
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
            if (timer > packageTimer)
            {
                //we die here
                
            }
        }
        else
        {
            timer = 0;
        }
    }
}
