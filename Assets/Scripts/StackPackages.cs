using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPackages : MonoBehaviour
{
    public GameObject package;
    public Vector3 dropLocation;
    public GameObject endOfTube;
    public GameObject target;
    public InventoryManager inventory;

    public void Stack(int type)
    {
        var obj = Instantiate(package);
        obj.transform.position = transform.position + dropLocation;
        obj.GetComponent<Package>().type = type;
        obj.GetComponent<Package>().endOfTube = endOfTube;
        obj.GetComponent<Package>().target = target;
        obj.GetComponent<Package>().inventory = inventory;
    }

}
