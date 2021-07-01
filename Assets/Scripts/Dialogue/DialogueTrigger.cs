using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : ItemInteractable
{
    public Dialogue dialogue;
    //아래 두 스위치 변수는 공란으로 둘 수 있음
    public Switch[] reqSwitch; //이 대화가 실행되기 위해 요하는 스위치

    [System.Serializable]
    public struct SwitchOnOffInf
    {
        public Switch[] onSwitchAfterDlg; //대화가 끝난 뒤 실행될 스위치
        public Switch[] offSwitchAfterDlg; //대화가 끝난 뒤 꺼질 스위치
    }

    public SwitchOnOffInf switchOnOffInf;

    public override void Interact()
    {
        base.Interact();

        bool allReqSwitchOn = true;
        if (reqSwitch != null)
        {
            for (int i = 0; i < reqSwitch.Length; i++)
            {
                if (!reqSwitch[i].getSwitchActive())
                {
                    allReqSwitchOn = false;
                }
            }
            if (allReqSwitchOn) TriggerDialogue();

        }
        else TriggerDialogue();

    }

    public void TriggerDialogue()
    {

        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

        //대화창이 사라졌을 경우에만 띄운다
        if (!dialogueManager.dialogueCanvas.activeSelf)
        {
            //얻을 아이템이 있다면 아이템을 얻도록 함 (switch가 필요한 경우를 위해)
            if (this.GetComponent<ItemPickup>()!= null &&
                this.GetComponent<ItemPickup>().item)
            {
                this.GetComponent<ItemPickup>().PickUp();
            }

            dialogueManager.dialogueCanvas.SetActive(true); //대화창 호출
            dialogueManager.StartDialogue(dialogue, switchOnOffInf);

        }
        else dialogueManager.setWaitFalse();
    }

}
