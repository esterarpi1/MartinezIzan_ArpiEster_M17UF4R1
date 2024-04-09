using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform items;
    InventorySlot[] slots;
    public GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.instance.onItemChangedCallBack += UpdateUI;

        slots = items.GetComponentsInChildren<InventorySlot>();
        InputController.Inventory += activeInventoryUI;
    }
    void activeInventoryUI()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < Inventory.instance.items.Count)
            {
                slots[i].AddItem(Inventory.instance.items[i]);
            }
            else
            {
                slots[i].RemoveItem();
            }
        }
    }
}
