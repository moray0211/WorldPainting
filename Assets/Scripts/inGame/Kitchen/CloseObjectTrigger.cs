using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseObjectTrigger : ItemInteractable
{
    public override void Interact()
    {
        base.Interact();
        this.GetComponentInParent<CloseObjcet>().setclose();
    }
}
