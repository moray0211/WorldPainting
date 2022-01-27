using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemPickup : ItemInteractable
{
    public Item item;
    public bool destroy = false;
    public bool destroy_thisComp = false;
    GameManager gameManager;

    public override void Interact()
    {
        base.Interact();
    }

    public void PickUp()
    {
        Debug.Log(name + "pickup");
        Inventory.instance.Add(item);
        if (destroy_thisComp)
        {
            Destroy(this);
        }
        if (destroy) {
            FindObjectOfType<EyeButtonAnimator>().deleteObject(this.name,this.tag);
            item.setItemDestory(true);
            Destroy(gameObject);
        }
    }


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (!gameManager.IsReset)
        {
            destoryIfNeeded();
        }
    }

    public void destoryIfNeeded()
    {
        if (item.getItemDestory())
        {
            Destroy(gameObject);
        }
    }

}
