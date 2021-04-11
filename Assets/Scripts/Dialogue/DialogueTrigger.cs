using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : ItemInteractable
{
    public Dialogue dialogue;
    public Switch reqSwitch;

    public override void Interact()
    {
        base.Interact();

        if(reqSwitch != null)
        {
            if(reqSwitch.getSwitchActive()) TriggerDialogue();
        }
        else TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        //대화창이 사라졌을 경우에만 띄운다
        if (!FindObjectOfType<DialogueManager>().dialogueCanvas.activeSelf)
        {
            FindObjectOfType<DialogueManager>().dialogueCanvas.SetActive(true); //대화창 호출
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        else FindObjectOfType<DialogueManager>().setWaitFalse();

    }

}
