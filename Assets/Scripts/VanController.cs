using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float drag;
    public float maxTurnSpeed;
    Vector2 currentVelocity;
    Vector2 currentAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GetAxis()
    {
        currentAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void CalculateNewSpeed()
    {
        //calculate drag
        currentVelocity -= currentVelocity * drag * Time.deltaTime;
        //calculate acceleration
        currentVelocity += acceleration * currentAxis * Time.deltaTime;


        //cap at max speed
        if(currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }
    }

    void FaceMoveDirection()
    {
        if (currentVelocity.magnitude == 0)
            return;
        //transform.LookAt(new Vector3(currentVelocity.x, 0, currentVelocity.y) + transform.position);
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(currentVelocity.x, 0, currentVelocity.y));
        float turnSpeed = Mathf.Min(maxTurnSpeed * Time.deltaTime, 1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        GetAxis();
        CalculateNewSpeed();
        FaceMoveDirection();
        transform.position += transform.forward * Time.deltaTime * currentVelocity.magnitude;
    }
}
