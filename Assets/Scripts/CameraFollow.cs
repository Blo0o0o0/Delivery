using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float maxNodAngle;
    public float minNodAngle;
    public float startNodAngle;
    public float cameraSensx;
    public float cameraSensy;
    public float smoothness;
    public Transform targetObject;
    public Animator otherAnim;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;
    private Quaternion cameraRotation;
    private Animator anim;
    private float goalRotation = 0;
    private float currentNodAngle;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        anim = GetComponent<Animator>();
        initalOffset = transform.position - targetObject.position;
        currentNodAngle = startNodAngle;
    }

    void LateUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        //nod the camera up and down with mouse movement
        currentNodAngle -= Input.GetAxis("Mouse Y") * cameraSensy;
        if(currentNodAngle < minNodAngle)
        {
            currentNodAngle = minNodAngle;
        }
        
        if(currentNodAngle > maxNodAngle)
        {
            currentNodAngle = maxNodAngle;
        }
        //position the camera and rotate it by mouse movement left and right
        goalRotation += Input.GetAxis("Mouse X") * cameraSensx;
        Quaternion rotation = Quaternion.Euler(0f, goalRotation, 0f);

        cameraPosition = Vector3.Lerp(cameraPosition, targetObject.position, smoothness * Time.deltaTime);
        cameraRotation = Quaternion.Euler(startNodAngle, goalRotation , transform.rotation.eulerAngles.z);
        transform.position = cameraPosition;
        transform.position += cameraRotation*initalOffset;
        transform.rotation = Quaternion.Euler(currentNodAngle, goalRotation, transform.rotation.eulerAngles.z);

 

        if(Input.GetMouseButton(1))
        {
            anim.SetBool("sucking", true);
        }
        else
        {
            anim.SetBool("sucking", false);
        }
        anim.SetBool("throwing", otherAnim.GetBool("Launching"));
    }

    public float getAngle()
    {
        return goalRotation;
    }
}