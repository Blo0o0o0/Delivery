using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorBuilding : MonoBehaviour
{
    public CollectorManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.AddCollector(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
