using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES_PL03 : IEventScript
{
    GameObject YellowStanding;
    GameObject MagentaStanding;
    public Dialogue MagentaTargetDialgoue;
    public Dialogue YellowTargetDialgoue;
    public override void StartEvent()
    {
        base.StartEvent();
        // 옐로우, 마젠타 화면에 띄워주기

        GameObject[] characterObjects = FindObjectOfType<EventManager>().CharacterObjects;
        YellowStanding = characterObjects[3];
        YellowStanding.SetActive(true);
        YellowStanding.AddComponent<DialogueTrigger>();
        YellowStanding.GetComponent<DialogueTrigger>().dialogue = YellowTargetDialgoue;
        YellowStanding.GetComponent<DialogueTrigger>().destroyThisComp = true;
        FindObjectOfType<BGMManager>().PlayTheme(3);

        /*
        MagentaStanding = characterObjects[1];
        MagentaStanding.SetActive(true);
        MagentaStanding.AddComponent<DialogueTrigger>();
        MagentaStanding.GetComponent<DialogueTrigger>().dialogue = MagentaTargetDialgoue;
        */

        GameObject.FindObjectOfType<DialogueManager>().StartDialogueWithDialogueID("DL_PL_04");
        // 화면에 띄운거 없애기
        EndEvent();
    }

    public override void EndEvent()
    {
        base.EndEvent();
    }
}
