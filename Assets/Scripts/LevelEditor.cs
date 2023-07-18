using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelEditor : MonoBehaviour
{
    //array of all possible pieces
    public GameObject piece;
    public TMP_InputField width;
    public TMP_InputField height;
    public Button generateButton;
    public Button saveButton;
    public float tileOffset;


    public float zoomSensitivity;
    public float moveSensitivity;

    public TextAsset map = null;
    public TMP_InputField saveFile;
    Dictionary<(int,int), GameObject> generatedPieces;
    private Vector2 previousMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        generatedPieces = new Dictionary<(int, int), GameObject>();
        generateButton.onClick.AddListener(GenerateNewGrid);
        saveButton.onClick.AddListener(SaveMap);
        previousMousePosition = Input.mousePosition;
        if (map != null)
        {
            //generate the map
            string fileContents = map.text;
            char[] whitespace = new char[] { ' ', '\t', '\n', '\r' };
            string[] words = fileContents.Split(whitespace, System.StringSplitOptions.RemoveEmptyEntries);
            //get the size
            int loadWidth = int.Parse(words[0].Split("x")[0]);
            int loadHeight = int.Parse(words[0].Split("x")[1]);

            width.text = loadWidth.ToString();
            height.text = loadHeight.ToString();
            int i = 0;
            for (int h = 0; h < loadHeight; h++)
            {
                for (int w = 0; w < loadWidth; w++)
                {
                    i++;
                    char type = words[i][0];
                    int numRotations = int.Parse(words[i].Substring(1));
                    GameObject obj = Instantiate(piece);
                    EditablePiece pieceScript = obj.GetComponent<EditablePiece>();
                    obj.transform.position = new Vector3(w, 0, -h) * tileOffset;
                    pieceScript.SetTypeByLetter(type);
                    pieceScript.Rotateint(numRotations);
                    generatedPieces.Add((w, h), obj);
                }
            }
        }
    }

    void GenerateNewGrid()
    {
        int newWidth = int.Parse(width.text);
        int newHeight = int.Parse(height.text);
        //disable all pieces
        foreach((int,int) key in generatedPieces.Keys)
        {
            generatedPieces[key].SetActive(false);
        }
        for(int w=0; w<newWidth; w++)
        {
            for(int h=0; h<newHeight; h++)
            {
                if(generatedPieces.ContainsKey((w,h)))
                {
                    generatedPieces[(w, h)].SetActive(true);
                }
                else
                {
                    GameObject obj = Instantiate(piece);
                    obj.transform.position = new Vector3(w, 0, -h) * tileOffset;
                    obj.GetComponent<EditablePiece>().SetTypeByLetter('g');
                    generatedPieces.Add((w, h), obj);
                }
            }
        }
    }
    private void Update()
    {
        float scrollInput = -Input.mouseScrollDelta.y;
        if (scrollInput != 0f)
        {

            Camera.main.orthographicSize += scrollInput * zoomSensitivity;
            if (Camera.main.orthographicSize < 1f)
            {
                Camera.main.orthographicSize = 1f;
            }
        }
        if(Input.GetMouseButton(2))
        {
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 mouseDelta = currentMousePosition - previousMousePosition;
            Vector3 moveAmount = new Vector3(mouseDelta.x, 0, mouseDelta.y) * moveSensitivity * Camera.main.orthographicSize;
            Camera.main.transform.position -= moveAmount;
        }
        previousMousePosition = Input.mousePosition;

    }

    void SaveMap()
    {
        print("hi");
        StringBuilder saveData = new StringBuilder();
        //add in the dimensions
        saveData.Append(width.text+"x"+ height.text+"\n");
        int newWidth = int.Parse(width.text);
        int newHeight = int.Parse(height.text);
        for (int h = 0; h < newHeight; h++)
        {
            for (int w = 0; w < newWidth; w++)
            {
                saveData.Append(generatedPieces[(w, h)].GetComponent<EditablePiece>().GetTypeChar() + generatedPieces[(w, h)].GetComponent<EditablePiece>().GetRotation() + " ");
            }
            saveData.Append("\n");
        }
        string filePath = Application.dataPath + "/" + saveFile.text + ".txt";
        print(filePath);
        // Create a new StreamWriter to write to the file
        StreamWriter writer = new StreamWriter(filePath);

        // Write the new text to the file
        writer.Write(saveData.ToString());

        // Close the writer to save changes and release resources
        writer.Close();

        // (Optional) Refresh the AssetDatabase to make Unity aware of the changes
        UnityEditor.AssetDatabase.Refresh();

    }
}
