using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilter : MonoBehaviour
{
    public GameObject leftWheel;
    public GameObject rightWheel;
    public GameObject tiltObject;
    public float tiltMultiplier;
    float untiltedHeight;
    int tiltAmountIndex;
    float prevRotation;
    Vector3 prevPosition;
    float[] tiltAmounts;


    float tiltAmountAverage()
    {
        float sum = 0;
        for(int i=0; i<tiltAmounts.Length; i++)
        {
            sum += tiltAmounts[i];
        }
        return sum / (float)(tiltAmounts.Length);
    }

    // Start is called before the first frame update
    void Start()
    {
        prevPosition = tiltObject.transform.position;
        prevRotation = tiltObject.transform.rotation.eulerAngles.y;
        tiltAmounts = new float[] { 0f, 0f, 0f, 0f};
    }

    private void Update()
    {
        if(prevRotation > 300 && tiltObject.transform.rotation.eulerAngles.y < 100)
        {
            prevRotation -= 360;
        }
        if (prevRotation < 100 && tiltObject.transform.rotation.eulerAngles.y > 300)
        {
            prevRotation += 360;
        }
        float rotationAmount = ((tiltObject.transform.rotation.eulerAngles.y - prevRotation)) / Time.deltaTime;

        
        float speed = Vector3.Distance(prevPosition, transform.position) / Time.deltaTime;
        if(speed < 8)
        {
            rotationAmount = 0;
        }
        tiltAmounts[tiltAmountIndex++] = rotationAmount * tiltMultiplier;
        if(rotationAmount > 100)
        {
            print(tiltObject.transform.rotation.eulerAngles.y);
            print(Time.deltaTime);
        }
        prevPosition = tiltObject.transform.position;
        prevRotation = tiltObject.transform.rotation.eulerAngles.y;
        if(tiltAmountIndex >= tiltAmounts.Length)
        {
            tiltAmountIndex = 0;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tiltObject.transform.rotation = Quaternion.Euler(tiltObject.transform.rotation.eulerAngles.x, tiltObject.transform.rotation.eulerAngles.y, tiltAmountAverage());
        untiltedHeight = tiltObject.transform.position.y;
        tiltObject.transform.position -= Vector3.up * untiltedHeight;
        tiltObject.transform.position += Vector3.up * (Mathf.Max(rightWheel.transform.position.y - tiltObject.transform.position.y, leftWheel.transform.position.y - tiltObject.transform.position.y));
    }
}
