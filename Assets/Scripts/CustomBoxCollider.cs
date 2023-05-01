using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBoxCollider : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool DoesCollide(Vector3 location, Vector3 boxSize)
    {
        Vector3 diff = location - (Vector3.Scale(center, transform.lossyScale) + transform.position);
        float x = Mathf.Abs(diff.x);
        float y = Mathf.Abs(diff.y);
        float z = Mathf.Abs(diff.z);
        return (x < boxSize.x + size.x * transform.lossyScale.x && y < boxSize.y + size.y * transform.lossyScale.y && z < boxSize.z + size.z * transform.lossyScale.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Draw the debug cuboid
        Gizmos.DrawWireCube(transform.position + Vector3.Scale(center, transform.lossyScale), Vector3.Scale(size, transform.lossyScale));
    }
}
