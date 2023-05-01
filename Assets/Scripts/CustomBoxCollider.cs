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
        Vector3 scaledSize = Vector3.Max(size, Vector3.Scale(boxSize, transform.lossyScale));
        return (x < scaledSize.x && y < scaledSize.y && z < scaledSize.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Draw the debug cuboid
        Gizmos.DrawWireCube(transform.position + Vector3.Scale(center, transform.lossyScale), Vector3.Scale(size, transform.lossyScale));
    }
}
