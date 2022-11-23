using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES_PL03 : IEventScript
{
    GameObject YellowStanding;
    GameObject MagentaStanding;
    public Dialogue MagentaTargetDialgoue;
    public Dialogue YellowTargetDialgoue;
    public Dialogue YellowBaseDialgoue;
    public Dialogue MagentaBaseDialgoue;
    public ItemInteractionObject YellowItemInteractionObject;
    public ItemInteractionObject MagentaItemInteractionObject;

    public AudioClip BellSound;
    public AudioClip tickSound;
    public override void StartEvent()
    {
        base.StartEvent();
        StartCoroutine("EventContent");
    }

    IEnumerator EventContent()
    {
        FindObjectOfType<SEManager>().playAudioClip(BellSound);
        FindObjectOfType<SEManager>().playAudioClip(tickSound);
        FindObjectOfType<BGMManager>().PlayTheme(3);

        // 옐로우 화면에 띄워주기
        FindObjectOfType<CharacterVisibleManager>().SetActiveCharacter(1);
        YellowStanding = FindObjectOfType<CharacterVisibleManager>().YellowObject;
        YellowStanding.SetActive(true);
        YellowStanding.AddComponent<DialogueTrigger>();
        YellowStanding.GetComponent<DialogueTrigger>().dialogue = YellowTargetDialgoue;
        YellowStanding.GetComponent<DialogueTrigger>().destroyThisComp = true;

        DialogueTrigger tem = YellowStanding.AddComponent<DialogueTrigger>();
        tem.dialogue = YellowBaseDialgoue;
        FindObjectOfType<BGMManager>().PlayTheme(3);

        Debug.Log("Before Paste ");
        ItemInteractionObject temitemyellow = YellowStanding.AddComponent<ItemInteractionObject>();

        temitemyellow.interactableItem = YellowItemInteractionObject.interactableItem;
        temitemyellow.destroyItem = YellowItemInteractionObject.destroyItem;
        temitemyellow.destroyObject = YellowItemInteractionObject.destroyObject;
        temitemyellow.isTriggerDiaglogue = YellowItemInteractionObject.isTriggerDiaglogue;
        temitemyellow.dialogue = YellowItemInteractionObject.dialogue;
        temitemyellow.reqSwitch = YellowItemInteractionObject.reqSwitch;
        temitemyellow.onSwitchAfterInteract = YellowItemInteractionObject.onSwitchAfterInteract;

        

        // 마젠타 화면에 띄워주기
        FindObjectOfType<CharacterVisibleManager>().SetActiveCharacter(0);
        MagentaStanding = FindObjectOfType<CharacterVisibleManager>().MagenObject;
        MagentaStanding.SetActive(true);
        MagentaStanding.AddComponent<DialogueTrigger>();
        MagentaStanding.GetComponent<DialogueTrigger>().dialogue = MagentaTargetDialgoue;
        MagentaStanding.GetComponent<DialogueTrigger>().destroyThisComp = true;

        yield return new WaitForSeconds(2.0f);
        FindObjectOfType<VisualEffectManager>().ChangeSceneFadeInOut("LibraryScene");

        
        DialogueTrigger temmagen = MagentaStanding.AddComponent<DialogueTrigger>();
        temmagen.dialogue = MagentaBaseDialgoue;

        ItemInteractionObject temitemmagenta = YellowStanding.AddComponent<ItemInteractionObject>();

        temitemmagenta.interactableItem = MagentaItemInteractionObject.interactableItem;
        temitemmagenta.destroyItem = MagentaItemInteractionObject.destroyItem;
        temitemmagenta.destroyObject = MagentaItemInteractionObject.destroyObject;
        temitemmagenta.isTriggerDiaglogue = MagentaItemInteractionObject.isTriggerDiaglogue;
        temitemmagenta.dialogue = MagentaItemInteractionObject.dialogue;
        temitemmagenta.reqSwitch = MagentaItemInteractionObject.reqSwitch;
        temitemmagenta.onSwitchAfterInteract = MagentaItemInteractionObject.onSwitchAfterInteract;

        yield return new WaitForSeconds(5.0f);

        FindObjectOfType<VisualEffectManager>().ChangeSceneFadeInOut("FrontScene");

        yield return new WaitForSeconds(1.0f);
        GameObject.FindObjectOfType<DialogueManager>().StartDialogueWithDialogueID("DL_PL_04");
        FindObjectOfType<BGMManager>().PlayTheme(0);
        // 화면에 띄운거 없애기
        EndEvent();
    }
    public override void EndEvent()
    {
        base.EndEvent();
    }
}
