using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPackage : MonoBehaviour
{
    public int packageType;
    public GameObject package;
    public Transform target;
    public float launchSpeed;
    public Transform launcher;
    public Transform spoon;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 CalculateLaunchVelocity(Vector3 startLocation, Vector3 destination)
    {
        Vector3 toTarget = destination - startLocation;

        // Calculate the flight time.
        float flightTime = toTarget.magnitude / launchSpeed;

        // Decompose the target displacement into x and y components.
        Vector3 toTargetXZ = toTarget;
        toTargetXZ.y = 0f;

        // Calculate the x and y components of the launch velocity.
        Vector3 launchVelocityXZ = toTargetXZ / flightTime;
        float launchVelocityY = (toTarget.y / flightTime) + (0.5f * Physics.gravity.magnitude * flightTime);

        // Combine the x and y components into a launch velocity vector.
        Vector3 launchVelocity = launchVelocityXZ;
        launchVelocity.y = launchVelocityY;

        return launchVelocity;
    }

    void Launch()
    {
        if(packageType == -1)
        {
            return;
        }
        var obj = Instantiate(package);
        obj.transform.position = spoon.position;
        //assign the type
        obj.GetComponent<Package>().type = packageType;
        obj.GetComponent<Rigidbody>().velocity = CalculateLaunchVelocity(spoon.position, target.position);

    }

    void RotateLauncher()
    {
        launcher.LookAt(new Vector3(target.position.x, launcher.position.y, target.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        RotateLauncher();
        if (Input.GetMouseButtonDown(0))
        {
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("launch") )
            {
                Launch();
                anim.SetBool("Launching", true);
            }
        }
        else
        {
            anim.SetBool("Launching", false);
        }
    }
}
