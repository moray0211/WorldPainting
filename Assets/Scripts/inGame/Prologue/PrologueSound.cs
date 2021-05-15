using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueSound : MonoBehaviour
{
    SEManager semanager;
    public AudioClip babyCrying;
    public AudioClip crowdSound;
    public AudioClip tvOffSound;
    public AudioClip keySound;

    bool readyKeySound = false;
    bool readyNextScene = false;

    void Start()
    {
        semanager = GameObject.Find("SEManager").GetComponent<SEManager>();
        StartCoroutine("prologueSound");
    }

    IEnumerator prologueSound()
    {
        semanager.playAudioClip(babyCrying);
        yield return new WaitForSeconds(3.5f);
        semanager.playAudioClip(crowdSound);
        yield return new WaitForSeconds(4f);
        semanager.stopAllAudioClip();
        semanager.playAudioClip(tvOffSound);
        yield return new WaitForSeconds(2.5f);
        semanager.stopAllAudioClip();
        yield return new WaitForSeconds(1.5f);
        this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().DisplayNextSentence();
        readyKeySound = true;
    }


    void Update()
    {
        if (readyKeySound && (!GameObject.Find("DialogueManager").GetComponent<DialogueManager>().inConversation))
        {
            semanager.playAudioClip(keySound);
            GameObject.Find("PrologueEvent2").GetComponent<DialogueTrigger>().TriggerDialogue();
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().DisplayNextSentence();
            readyKeySound = false;
            readyNextScene = true;
        }

        if (readyNextScene && (!GameObject.Find("DialogueManager").GetComponent<DialogueManager>().inConversation))
        {
            SceneManager.LoadScene("SampleScene");
            readyNextScene = false;
        }
    }

}
