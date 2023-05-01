using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public List<Material> materials;
    public int type;
    public float hitDistance;
    public GameObject target;
    public GameObject endOfTube;
    public float suckSpeed;
    public float destroyDistance;
    public float destroyTime;
    public InventoryManager inventory;
    public AudioClip hitSound;
    bool sucking = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().sharedMaterial = materials[type];
    }

    // Update is called once per frame
    void Update()
    {
        if(sucking)
        {
            transform.position = Vector3.Slerp(transform.position, endOfTube.transform.position, suckSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, endOfTube.transform.position) < destroyDistance)
            {
                Destroy(gameObject, destroyTime);
            }
        }
        else if(Input.GetMouseButton(1) && Vector3.Distance(transform.position, target.transform.position) < hitDistance)
        {
            sucking = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        if(Input.GetMouseButtonUp(1) && Vector3.Distance(transform.position, endOfTube.transform.position) > destroyDistance)
        {
            sucking = false;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    private void OnDestroy()
    {
        if(sucking)
        {
            //add it to the inventory
            inventory.AddItem(type);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
    }
}
