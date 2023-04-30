using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public float timeBetweenPackages;
    public int maxPackagesInOne;
    public float maxPackagesTime;
    public CollectorManager collectorManager;
    float timer;
    public List<GeneratorBuilding> generators;
    // Start is called before the first frame update
    void Start()
    {
        //generators = new List<GeneratorBuilding>();
    }

    public void AddGenerator(GeneratorBuilding generator)
    {
        print(generator);
        print(generators);
        print("hi");
        generators.Add(generator);
        print(generators);
    }

    //choose a random generator and generate a package there.
    void Generate()
    {
        print(generators);
        print(Random.Range(0, generators.Count));
        int type = generators[Random.Range(0, generators.Count)].Generate();

        //assign the package to a collector
        collectorManager.AddPackageToCollector(type);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeBetweenPackages)
        {
            timer = 0;
            Generate();
        }
    }
}
