using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEInteract : ItemInteractable
{

    //상호작용시 SE가 발생하는 스크립트
    public AudioClip soundEffect;
    public Switch reqSwitch; //없을시 무시한다

    public override void Interact()
    {
        base.Interact();
        if(reqSwitch != null) //SE가 실행되기 위해 필요한 스위치가 있다면
        {
            if (reqSwitch.isSwitchActive) //스위치가 켜져있을 경우
            {
                if (!GameObject.Find("DialogueManager").GetComponent<DialogueManager>().inConversation)
                    GameObject.Find("SEManager").GetComponent<SEManager>().playAudioClip(soundEffect);
            }
        }
       
    }
}
