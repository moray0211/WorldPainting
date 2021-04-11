using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEInteract : ItemInteractable
{

    //상호작용시 SE가 발생하는 스크립트
    public AudioClip soundEffect;

    public override void Interact()
    {
        base.Interact();
        if(!GameObject.Find("DialogueManager").GetComponent<DialogueManager>().inConversation)
        GameObject.Find("SEManager").GetComponent<SEManager>().playAudioClip(soundEffect);
    }
}
