using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologue_inRoom : MonoBehaviour
{
    SEManager semanager;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    bool readyWhisperSound = false;
    public AudioClip whisperSound;
    public Switch prologueEndSwitch;

    // Start is called before the first frame update
    void Start()
   {
        semanager = GameObject.Find("SEManager").GetComponent<SEManager>();
        StartCoroutine("Prologue_inRoom_play");
    }

    IEnumerator Prologue_inRoom_play()
    {
        //인벤토리 비활성화
        Inventory.instance.InventorySetActive(false);

        semanager.playAudioClip(doorOpen);
        yield return new WaitForSeconds(doorOpen.length);
        semanager.playAudioClip(doorClose);
        yield return new WaitForSeconds(doorClose.length);

        //인벤토리 재활성화
        Inventory.instance.InventorySetActive(true);

        this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().DisplayNextSentence();
        readyWhisperSound = true;
    }

    void Update()
    {
        if (readyWhisperSound && (!GameObject.Find("DialogueManager").GetComponent<DialogueManager>().inConversation))
        {
            semanager.playAudioClip(whisperSound);
            GameObject.Find("FirstEvent-2").GetComponent<DialogueTrigger>().TriggerDialogue();
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().DisplayNextSentence();
            //prologueEndSwitch.setSwitchActive(true); //프롤로그 대사 끝
            readyWhisperSound = false;
        }

    }
}
