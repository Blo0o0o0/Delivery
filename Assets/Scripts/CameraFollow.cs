using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothness;
    public Transform targetObject;
    public Animator otherAnim;
    private Vector3 initalOffset;
    private Vector3 initalOffset1;
    private Vector3 initalOffset2;
    private Vector3 initalOffset3;
    private Vector3 initalOffset4;
    private Vector3 initialOffset;
    public int currentOffset;
    private Vector3 cameraPosition;
    private Quaternion cameraRotation;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        initalOffset1 = transform.position - targetObject.position;
        initalOffset = initalOffset1;
        initalOffset2 = new Vector3(initalOffset.z, initalOffset.y, initalOffset.x);
        initalOffset3 = new Vector3(initalOffset.x, initalOffset.y, -initalOffset.z);
        initalOffset4 = new Vector3(-initalOffset.z, initalOffset.y, initalOffset.x);
    }

    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            currentOffset--;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            currentOffset++;
        }
        while(currentOffset<0)
        {
            currentOffset += 4;
        }
        currentOffset %= 4;
        switch(currentOffset)
        {
            case 0:
                initalOffset = initalOffset1;
                break;
            case 1:
                initalOffset = initalOffset2;
                break;
            case 2:
                initalOffset = initalOffset3;
                break;
            case 3:
                initalOffset = initalOffset4;
                break;
        }
        cameraPosition = targetObject.position + initalOffset;
        cameraRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 90 * currentOffset, transform.rotation.eulerAngles.z);
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness*Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, smoothness*Time.deltaTime);
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
}