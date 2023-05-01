using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFoliageRandomly : MonoBehaviour
{
    public List<GameObject> foliage;
    public Vector2 Variance;
    public float initHeight;
    public float probsToPlace;
    public float stepSize;
    public float start;
    public float end;
    // Start is called before the first frame update
    void Start()
    {
        for(int x=0; x<(int)(end-start)/stepSize; x++)
        {
            for (int y = 0; y < (int)(end - start) / stepSize; y++)
            {
                if(Random.Range(0f,1f) < probsToPlace)
                {
                    print("Hi");
                    var obj = Instantiate(foliage[Random.Range(0, foliage.Count)]);
                    obj.transform.position = transform.position + new Vector3(start + x * stepSize, initHeight, start + y * stepSize) + new Vector3(Random.Range(-Variance.x, Variance.x), 0, Random.Range(-Variance.y, Variance.y));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
