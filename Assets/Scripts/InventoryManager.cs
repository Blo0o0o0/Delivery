using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Text inventoryText;

    int[] inventory = {0, 0, 0, 0, 0, 0, 0, 0};
    public string[] itemNames = {"Meat", "Bread", "Milk", "Takeaway", "Ice Cream", "Pizza", "Curry", "Groceries"};
    public int maxParcels;
    public LaunchPackage launcher;
    public float scrollSens;
    int currentParcels;
    int currentlyHeld = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // for all the items in the inventory
        for(int i = 0; i < inventory.Length; i++)
        {
            inventoryText.text += itemNames[i].ToString() + ": " + inventory[i].ToString() + "\n";
        }
        inventoryText.text += "Currently Selected: " + itemNames[currentlyHeld];


    }

    void Update()
    {
        // reset the inventory
        inventoryText.text = "";
        for(int i = 0; i < inventory.Length; i++)
        {
            inventoryText.text += itemNames[i].ToString() + ": " + inventory[i].ToString() + "\n";
        }
        SetType(((int)(Input.mouseScrollDelta.y * scrollSens)));
        inventoryText.text += "Currently Selected: " + itemNames[currentlyHeld];
    }

    void SetType(int change)
    {
        //set the 
        currentlyHeld += change;
        while(currentlyHeld < 0)
        {
            currentlyHeld += itemNames.Length;
        }
        currentlyHeld %= itemNames.Length;
        launcher.packageType = currentlyHeld;
    }


    public void AddItem(int ID)
    {
        inventory[ID]++;
        currentParcels++;
    }

    public int ShootItem(int ID)
    {
        if(inventory[ID] <= 0)
        {
            return -1;
        }
        else
        {
            inventory[ID]--;
            currentParcels--;
            return 0;
        }
    }

    public int GetItem(int ID)
    {
        return inventory[ID];
    }

    public void SetItem(int ID, int amount)
    {
        currentParcels += (amount - inventory[ID]);
        inventory[ID] = amount;
    }

}
