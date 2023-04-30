using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private void LateUpdate()
    {
        // Get the camera position
        Vector3 camPosition = Camera.main.transform.position;

        // Make the object face the camera
        transform.LookAt(new Vector3(camPosition.x, transform.position.y, camPosition.z));

        // Lock the rotation to the y-axis
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
