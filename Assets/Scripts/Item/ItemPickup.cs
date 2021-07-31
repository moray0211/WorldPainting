using System.Collections;
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
            FindObjectOfType<EyeButtonAnimator>().deleteObject(this.name,this.tag);
            Destroy(gameObject);
        }
    }
}
