using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingScript : MonoBehaviour
{
    public LayerMask targetable;
    public Transform van;
    public float maxDistanceFromVan;
    Ray ray;
    RaycastHit hitInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //raycast the target to the mouse position
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, targetable))
        {
            transform.position = hitInfo.point;
            //normalise it into the maxdistance
            if(Vector3.Distance(transform.position, van.position) > maxDistanceFromVan)
            {
                transform.position = (transform.position - van.position).normalized * maxDistanceFromVan + van.position;
            }
        }
    }
}
