using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    public static InventoryItems Instance;

    public Item Axe;
    public Item Shield;
    public Item Sword;
    
    public List<Item> Items;
    public List<Item> inventory;

    public void checkInventory(string[] _inventory)
    {
        Items = new List<Item> { Axe, Shield, Sword };
        for(int i = 0; i < _inventory.Length; i++)
        {
            if (_inventory[i] == Items[i].name)
            {
                inventory.Add(Items[i]);
            }
        }

        Inventory.instance.clearInventory();
        foreach(Item item in inventory)
        {
            Inventory.instance.Add(item);
        }

    }
}
