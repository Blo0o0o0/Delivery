using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothness;
    public Transform targetObject;
    public Animator otherAnim;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        initalOffset = transform.position - targetObject.position;
    }

    void LateUpdate()
    {
        cameraPosition = targetObject.position + initalOffset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness*Time.deltaTime);
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