using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorIcons : MonoBehaviour
{
    public List<GameObject> iconList;
    List<GameObject> instantiated;
    GameObject obj;

    private void Start()
    {
        instantiated = new List<GameObject>();
    }
    public void Display(List<int> types)
    {
        //clear children
        foreach(GameObject obj in instantiated)
        {
            Destroy(obj);
        }
        int i = 0;
        foreach(int type in types)
        {
            obj = Instantiate(iconList[type]);
            obj.transform.position = transform.GetChild(i++).position;
            instantiated.Add(obj);

        }
    }
}
