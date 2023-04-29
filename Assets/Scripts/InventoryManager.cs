using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Text inventoryText;

    int[] inventory = {0, 0, 0, 0, 0, 0, 0, 0};
    string[] itemNames = {"Meat", "Bread", "Milk", "Takeaway", "Ice Cream", "Pizza", "Curry", "Groceries"};
    static int maxParcels;
    int currentParcels;
    
    // Start is called before the first frame update
    void Start()
    {
        // for all the items in the inventory
        for(int i = 0; i < inventory.Length; i++)
        {
            inventoryText.text += itemNames[i].ToString() + ": " + inventory[i].ToString() + "\n";
        }
    }

    void Update()
    {
        // reset the inventory
        inventoryText.text = "";
        for(int i = 0; i < inventory.Length; i++)
        {
            inventoryText.text += itemNames[i].ToString() + ": " + inventory[i].ToString() + "\n";
        }
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
