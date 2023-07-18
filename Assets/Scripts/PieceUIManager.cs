using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PieceUIManager : MonoBehaviour
{
    public Button rotateLeft;
    public Button rotateRight;
    public Button nextPiece;
    public Button previousPiece;
    public TMP_Text type;
    public EditablePiece selectedPiece;
    // Start is called before the first frame update
    void Start()
    {
        rotateLeft.onClick.AddListener(RotateL);
        rotateRight.onClick.AddListener(RotateR);
        nextPiece.onClick.AddListener(PieceN);
        previousPiece.onClick.AddListener(PieceP);
    }

    void PieceN()
    {
        selectedPiece.ChangeType(false);
    }
    void PieceP()
    {
        selectedPiece.ChangeType(true);
    }

    void RotateL()
    {
        selectedPiece.Rotate(false);
    }
    void RotateR()
    {
        selectedPiece.Rotate(true);
    }
    private void DisableChildren(Transform parent, bool active=false)
    {
        int childCount = parent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = parent.GetChild(i);
            child.gameObject.SetActive(active);
            DisableChildren(child, active);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(selectedPiece == null)
        {
            DisableChildren(transform);
        }
        else
        {
            DisableChildren(transform, true);
        }

        type.text = selectedPiece.transform.GetChild(0).name.Substring(0, selectedPiece.transform.GetChild(0).name.Length - 7);
    }
}
