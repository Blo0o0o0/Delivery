using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorManager : MonoBehaviour
{
    List<CollectorBuilding> collectors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddCollector(CollectorBuilding collector)
    {
        collectors.Add(collector);
    }

    //add a desire for a package of type type to a random collector
    public void AddPackageToCollector(int type)
    {
        //collectors[Random.Range(0, collectors.Count)];
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
