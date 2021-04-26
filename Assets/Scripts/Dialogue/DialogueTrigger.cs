using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : ItemInteractable
{
    public Dialogue dialogue;
    //아래 두 스위치 변수는 공란으로 둘 수 있음
    public Switch reqSwitch; //이 대화가 실행되기 위해 요하는 스위치
    public Switch onSwitchAfterDlg; //대화가 끝난 뒤 실행될 스위치

    public override void Interact()
    {
        base.Interact();

        if(reqSwitch != null)
        {
            if(reqSwitch.isSwitchActive) TriggerDialogue();
        }
        else TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        //대화창이 사라졌을 경우에만 띄운다
        if (!FindObjectOfType<DialogueManager>().dialogueCanvas.activeSelf)
        {
            FindObjectOfType<DialogueManager>().dialogueCanvas.SetActive(true); //대화창 호출
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, onSwitchAfterDlg);
        }
        else FindObjectOfType<DialogueManager>().setWaitFalse();

    }

}
