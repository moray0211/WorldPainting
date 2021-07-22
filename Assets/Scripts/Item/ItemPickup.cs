﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : ItemInteractable
{
    public Item item;
    public bool destroy = false;
    GameManager gameManager;
    void Start(){
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override void Interact()
    {
        base.Interact();
    }

    public void PickUp()
    {
        Inventory.instance.Add(item);
        if (destroy) {
            //gameManager.setInactive(gameObject.name);
            Destroy(gameObject);
        }
    }
}
