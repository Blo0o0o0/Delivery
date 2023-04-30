using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckTube : MonoBehaviour
{
    public GameObject baseArmature;
    public float wobbleRate;
    public float unWobbleRate;
    public float timeMultiplier;
    public float growRate;
    public float maxSize;
    public float minSize;
    public float shrinkRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Wobble();
        }
        else
        {
            UnWobble();
        }
    }
    void UnWobble()
    {
        GameObject arm = baseArmature;
        int i = 0;
        do
        {

            i++;
            arm.transform.localRotation = Quaternion.Lerp(arm.transform.localRotation, Quaternion.identity, Time.deltaTime*unWobbleRate);
            arm = arm.transform.GetChild(0).gameObject;
        }
        while (arm.transform.childCount != 0);
        if(baseArmature.transform.parent.localScale.x > minSize)
        {
            baseArmature.transform.parent.localScale *= (1-shrinkRate*Time.deltaTime);
        }
        else
        {
            baseArmature.transform.parent.localScale = Vector3.one * minSize;
        }
    }

    void Wobble()
    {
        GameObject arm = baseArmature;
        int i = 0;
        do
        {

            i++;
            arm.transform.localRotation = Quaternion.Euler(new Vector3((Mathf.PerlinNoise(i + 0.12435f, Time.unscaledTime * timeMultiplier) - 0.5f) * wobbleRate, (Mathf.PerlinNoise(i + 0.12435f, Time.unscaledTime * timeMultiplier) - 0.5f) * wobbleRate, (Mathf.PerlinNoise(i + 0.12435f, Time.unscaledTime * timeMultiplier) - 0.5f) * wobbleRate) * Time.deltaTime + arm.transform.localRotation.eulerAngles);
            arm = arm.transform.GetChild(0).gameObject;
        }
        while (arm.transform.childCount != 0);
        if (baseArmature.transform.parent.localScale.x < maxSize)
        {
            baseArmature.transform.parent.localScale *= (1+growRate*Time.deltaTime);
        }
        else
        {
            baseArmature.transform.parent.localScale = Vector3.one * maxSize;
        }
    }
}
