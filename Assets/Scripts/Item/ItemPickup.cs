using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : ItemInteractable
{
    public Item item;
    public bool destroy = false;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Inventory.instance.Add(item);
        if (destroy) Destroy(gameObject);
    }
}
