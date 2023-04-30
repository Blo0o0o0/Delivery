using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public float tileSize;
    public Vector3 startPosition;
    public GameObject end;
    public GameObject tJunction;
    public GameObject straight;
    public GameObject turn;
    public GameObject grass;
    public GameObject cross;
    public TextAsset map;

    string fileContents;
    // Start is called before the first frame update
    void Start()
    {
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
                }
                obj.transform.position = startPosition + tileSize * x * Vector3.right + tileSize * y * Vector3.forward;
                obj.transform.rotation = Quaternion.Euler(new Vector3(obj.transform.rotation.eulerAngles.x, 90 * numRotations, obj.transform.eulerAngles.z));
                //obj.transform.Rotate(0, 90 * numRotations, 0);
                //obj.transform.localScale *= tileSize;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
