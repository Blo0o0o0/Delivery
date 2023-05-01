using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject endOfTube;
    public GameObject target;
    public InventoryManager inventory;
    public float tileSize;
    public float tileScale;
    public Vector3 startPosition;
    public GameObject end;//e
    public GameObject tJunction;//t
    public GameObject straight;//s
    public GameObject turn;//c
    public GameObject grass;//g
    public GameObject cross;//x
    public GameObject butchers;//b
    public GameObject bakers;//a
    public GameObject dairy;//d
    public GameObject takeaway;//k
    public GameObject iceCream;//i
    public GameObject pizzaria;//p
    public GameObject curry;//u
    public GameObject groceries;//r
    public GameObject house;//h
    public GameObject fence;//f
    public TextAsset map;

    public GameObject score;
    

    string fileContents;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        fileContents = map.text;
        char[] whitespace = new char[] { ' ', '\t', '\n', '\r' };
        string[] words = fileContents.Split(whitespace, System.StringSplitOptions.RemoveEmptyEntries);
        //get the size
        int width = int.Parse(words[0].Split("x")[0]);
        int height = int.Parse(words[0].Split("x")[1]);
        int i = 0;
        for(int y=0; y<height; y++)
        {
            for(int x=0; x<width; x++)
            {
                i++;
                char type = words[i][0];
                int numRotations = int.Parse(words[i].Substring(1));
                GameObject obj = null;
                switch(type)
                {
                    case 'c':
                        obj = Instantiate(turn);
                        break;
                    case 'e':
                        obj = Instantiate(end);
                        break;
                    case 't':
                        obj = Instantiate(tJunction);
                        break;
                    case 's':
                        obj = Instantiate(straight);
                        break;
                    case 'x':
                        obj = Instantiate(cross);
                        break;
                    case 'g':
                        obj = Instantiate(grass);
                        break;
                    case 'b':
                        obj = Instantiate(butchers);
                        obj.GetComponent<GeneratorBuilding>().manager = GetComponent<GeneratorManager>();
                        obj.GetComponent<GeneratorBuilding>().gameOver = GetComponent<GameOver>();
                        obj.GetComponentInChildren<StackPackages>().target = target;
                        obj.GetComponentInChildren<StackPackages>().endOfTube = endOfTube;
                        obj.GetComponentInChildren<StackPackages>().inventory = inventory;
                        break;
                    case 'a':
                        obj = Instantiate(bakers);
                        obj.GetComponent<GeneratorBuilding>().manager = GetComponent<GeneratorManager>();
                        obj.GetComponent<GeneratorBuilding>().gameOver = GetComponent<GameOver>();
                        obj.GetComponentInChildren<StackPackages>().target = target;
                        obj.GetComponentInChildren<StackPackages>().endOfTube = endOfTube;
                        obj.GetComponentInChildren<StackPackages>().inventory = inventory;
                        break;
                    case 'd':
                        obj = Instantiate(dairy);
                        obj.GetComponent<GeneratorBuilding>().manager = GetComponent<GeneratorManager>();
                        obj.GetComponent<GeneratorBuilding>().gameOver = GetComponent<GameOver>();
                        obj.GetComponentInChildren<StackPackages>().target = target;
                        obj.GetComponentInChildren<StackPackages>().endOfTube = endOfTube;
                        obj.GetComponentInChildren<StackPackages>().inventory = inventory;
                        break;
                    case 'i':
                        obj = Instantiate(iceCream);
                        obj.GetComponent<GeneratorBuilding>().manager = GetComponent<GeneratorManager>();
                        obj.GetComponent<GeneratorBuilding>().gameOver = GetComponent<GameOver>();
                        obj.GetComponentInChildren<StackPackages>().target = target;
                        obj.GetComponentInChildren<StackPackages>().endOfTube = endOfTube;
                        obj.GetComponentInChildren<StackPackages>().inventory = inventory;
                        break;
                    case 'k':
                        obj = Instantiate(takeaway);
                        obj.GetComponent<GeneratorBuilding>().manager = GetComponent<GeneratorManager>();
                        obj.GetComponent<GeneratorBuilding>().gameOver = GetComponent<GameOver>();
                        obj.GetComponentInChildren<StackPackages>().target = target;
                        obj.GetComponentInChildren<StackPackages>().endOfTube = endOfTube;
                        obj.GetComponentInChildren<StackPackages>().inventory = inventory;
                        break;
                    case 'p':
                        obj = Instantiate(pizzaria);
                        obj.GetComponent<GeneratorBuilding>().manager = GetComponent<GeneratorManager>();
                        obj.GetComponent<GeneratorBuilding>().gameOver = GetComponent<GameOver>();
                        obj.GetComponentInChildren<StackPackages>().target = target;
                        obj.GetComponentInChildren<StackPackages>().endOfTube = endOfTube;
                        obj.GetComponentInChildren<StackPackages>().inventory = inventory;
                        break;
                    case 'u':
                        obj = Instantiate(curry);
                        obj.GetComponent<GeneratorBuilding>().manager = GetComponent<GeneratorManager>();
                        obj.GetComponent<GeneratorBuilding>().gameOver = GetComponent<GameOver>();
                        obj.GetComponentInChildren<StackPackages>().target = target;
                        obj.GetComponentInChildren<StackPackages>().endOfTube = endOfTube;
                        obj.GetComponentInChildren<StackPackages>().inventory = inventory;
                        break;
                    case 'r':
                        obj = Instantiate(groceries);
                        obj.GetComponent<GeneratorBuilding>().manager = GetComponent<GeneratorManager>();
                        obj.GetComponent<GeneratorBuilding>().gameOver = GetComponent<GameOver>();
                        obj.GetComponentInChildren<StackPackages>().target = target;
                        obj.GetComponentInChildren<StackPackages>().endOfTube = endOfTube;
                        obj.GetComponentInChildren<StackPackages>().inventory = inventory;
                        break;
                    case 'h':
                        obj = Instantiate(house);
                        obj.GetComponent<CollectorBuilding>().score = score.GetComponent<ScoreManager>();
                        obj.GetComponent<CollectorBuilding>().manager = GetComponent<CollectorManager>();
                        break;
                    case 'f':
                        obj = Instantiate(fence);
                        break;

                }
                //badkipur
                obj.transform.position = startPosition + tileSize * tileScale * x * Vector3.right + tileSize * tileScale * -y * Vector3.forward;
                obj.transform.rotation = Quaternion.Euler(new Vector3(0, 90 * numRotations, 0));
                //obj.transform.Rotate(0, 90 * numRotations, 0);
                obj.transform.localScale *= tileScale * 1.001f;
                obj.gameObject.layer = 3;
                obj.AddComponent<MeshCollider>();
                obj.transform.parent = transform;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
