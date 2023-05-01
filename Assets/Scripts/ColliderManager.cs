using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public CustomBoxCollider[] colliders;
    // Start is called before the first frame update
    void Start()
    {
        colliders = new CustomBoxCollider[] { };
    }

    public bool isColliding(Vector3 location, Vector3 boxSize)
    {
        foreach(CustomBoxCollider collider in colliders)
        {
            if(collider.DoesCollide(location, boxSize))
            {
                return true;
            }

        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(colliders.Length == 0)
        {
            colliders = FindObjectsOfType<CustomBoxCollider>();
        }
    }
}
