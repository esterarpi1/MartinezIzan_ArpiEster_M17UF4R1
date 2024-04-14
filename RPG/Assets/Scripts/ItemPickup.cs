using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : IInteractable
{
    public Item item;
    public AudioSource pickUpObject;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        if(Inventory.instance.Add(item)) Destroy(gameObject);
        //GameManager.Instance.objectsToBeFound -= 1;
        pickUpObject.Play();
    }
}
