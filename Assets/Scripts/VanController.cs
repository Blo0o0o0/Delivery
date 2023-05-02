using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float drag;
    public float maxTurnSpeed;
    public Animator anim;
    public ColliderManager collisions;
    public Vector3 colliderCentre;
    public Vector3 colliderSize;
    public AudioSource collisionSound;
    public AudioSource vroomSound;
    public LayerMask targetable;
    public float height;
    public CameraFollow cam;
    Vector2 currentVelocity;
    Vector2 currentAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GetAxis()
    {
        Quaternion rot = Quaternion.Euler(0, 0, -cam.currentOffset * 90);
        currentAxis = rot* new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(currentAxis.magnitude > 0)
        {
            anim.SetBool("driving", true);
        }
        else
        {
            anim.SetBool("driving", false);
        }
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

    public float GetSpeed()
    {
        return currentVelocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        GetAxis();
        CalculateNewSpeed();
        FaceMoveDirection();
        Vector3 rotatedCollider = colliderSize;
        if(Mathf.Abs(currentVelocity.y) < Mathf.Abs(currentVelocity.x))
        {
            rotatedCollider = new Vector3(colliderSize.z, colliderSize.y, colliderSize.x);
        }
        Vector3 newPosition =transform.position + transform.forward * Time.deltaTime * currentVelocity.magnitude;
        if (!collisions.isColliding(newPosition + Vector3.Scale(transform.lossyScale, colliderCentre), rotatedCollider))
        {
            transform.position = newPosition;
        }
        else
        {
            if(!collisionSound.isPlaying)
                collisionSound.Play();
        }
        vroomSound.pitch = 1 + (currentVelocity.magnitude) / (maxSpeed * 2);

        //adjust height
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 1, -(Vector3.up), out hit, Mathf.Infinity, targetable))
        {
            transform.position = transform.position - transform.position.y * Vector3.up + Vector3.up * (hit.point.y + height);
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 rotatedCollider = colliderSize;
        if (Mathf.Abs(currentVelocity.y) < Mathf.Abs(currentVelocity.x))
        {
            rotatedCollider = new Vector3(colliderSize.z, colliderSize.y, colliderSize.x);
        }

        Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * currentVelocity.magnitude;
        Gizmos.DrawWireCube(newPosition + Vector3.Scale(transform.lossyScale, colliderCentre), rotatedCollider);
    }
}
