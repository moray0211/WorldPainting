using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES_PL01 : IEventScript
{
    public override void StartEvent()
    {
        base.StartEvent();
        GameObject.FindObjectOfType<DialogueManager>().StartDialogueWithDialogueID("DL_PL_01");
    }

    public override void EndEvent()
    {
        base.EndEvent();
    }
}
