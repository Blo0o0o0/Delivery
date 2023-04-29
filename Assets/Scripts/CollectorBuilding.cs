using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorBuilding : MonoBehaviour
{
    public CollectorManager manager;
    public ScoreManager score;
    public int packagesLayer;
    public List<int> packages;
    int maxPackages = 3;
    // Start is called before the first frame update
    void Start()
    {
        manager.AddCollector(this);
    }

    public bool AddPackage(int type)
    {
        if(packages.Count > maxPackages)
        {
            return false;
        }
        packages.Add(type);
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == packagesLayer)
        {
            //get the package type
            int type = other.GetComponent<Package>().type;
            if(packages.Contains(type))
            {
                packages.Remove(type);
                //add score
                score.AddPoints(1);
            }
            else
            {
                //subtract score
                score.AddPoints(-1);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
