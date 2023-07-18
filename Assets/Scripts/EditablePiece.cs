using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class MyTuple
{
    public GameObject piece;
    public char character;
}
public class EditablePiece : MonoBehaviour
{
    public PieceUIManager UIStuff;
    public List<MyTuple> pieceTypes;
    bool selected;
    int rotation;
    int type;
    float bobSpeed = 2;
    float bobAmount = 0.1f;
    Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        UIStuff = FindAnyObjectByType<PieceUIManager>();
        originalScale = transform.localScale;
    }
    public void SetTypeByLetter(char letter)
    {
        for(int i=0; i<pieceTypes.Count; i++)
        {
            if (pieceTypes[i].character == letter)
            {
                UpdateType(i);
                return;
            }
        }
    }
    public int GetRotation()
    {
        return rotation;
    }
    public string GetTypeChar()
    {
        return pieceTypes[type].character.ToString();
    }
    public void Rotateint(int newRotation)
    {
        rotation = newRotation;
        transform.rotation = Quaternion.Euler(new Vector3(0, 90 * rotation, 0));
        rotation %= 4;
    }

    public void ChangeType(bool left)
    {
        int newType = type;
        if (left)
            newType--;
        else
            newType++;
        newType += pieceTypes.Count;
        newType %= pieceTypes.Count;
        UpdateType(newType);
    }
    private void UpdateType(int newType)
    {
        type = newType;
        if(transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);
        var obj = Instantiate(pieceTypes[newType].piece);
        obj.AddComponent<MeshCollider>();
        obj.transform.parent = transform;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;
    }
    public void Rotate(bool left)
    {
        if (left)
        {
            rotation++;
        }
        else
        {
            rotation--;
        }
        transform.rotation = transform.rotation = Quaternion.Euler(new Vector3(0, 90 * rotation, 0));
        rotation %= 4;
    }

    private void Update()
    {
        if (selected)
            transform.localScale = originalScale * (1 + (Mathf.Sin(bobSpeed * Time.time) * bobAmount));
        else
            transform.localScale = originalScale;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // Check if left mouse button is clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject || hit.collider.gameObject.transform.IsChildOf(transform)) // Check if the raycast hits the current GameObject
                {
                    // Call your desired function or perform actions here
                    selected = true;
                    UIStuff.selectedPiece = this;
                }
                else
                {
                    selected = false;
                }
            }
            else
            {
                selected = false;
                UIStuff.selectedPiece = null;
            }
            
        }
    }
    private void OnDisable()
    {
        if(selected)
            UIStuff.selectedPiece = null;
        selected = false;

    }
}
