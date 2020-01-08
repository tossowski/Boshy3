using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that represents a player inventory.
public class Inventory : MonoBehaviour
{
    private Transform inv; // The inventory thing in the canvas
    private int maxSize = 20;

    private int numItems = 0; // current amount of items.
    public Item[] items;
    void Start()
    {
        //inv = GameObject.Find("Canvas").transform.Find("Inventory").Find("Items");
        items = new Item[maxSize];
        numItems = 0;
    }

    // Adds item to first available open slot.
    public void addItem(Item item)
    {
        if (numItems < maxSize)
        {
            for (int i = 0; i < maxSize; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    // Load in inventory item prefab and set its item.
                    //GameObject invItem = Resources.Load("GUI/InventoryItem") as GameObject;
                    //GameObject slot = Instantiate(invItem, Vector3.zero, Quaternion.identity);
                    //slot.transform.SetParent(inv.GetChild(i), false);
                    //slot.GetComponent<InventoryItem>().setItem(item);
                    numItems++;
                    return;
                }
            }
        }
        else
        {
            return;
            //Display.Message.displayErrorMessage("Inventory Full!");
        }
    }

    public bool contains(string name)
    {
        foreach (Item item in items)
        {
            if ((object)item != null && item.getName().Equals(name))
            {
                return true;
            }
        }
        return false;
    }
}
