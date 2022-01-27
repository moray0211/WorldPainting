using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToChangeScene : ItemInteractable
{
    public string sceneName;
    public AudioClip audioClip; //화면 이동시 재생될 SE

    public override void Interact()
    {
        base.Interact();
        if(sceneName != null)
        {
            FindObjectOfType<GameManager>().IsStart = false;
            //SE 재생
            if (audioClip != null) GameObject.Find("SEManager").GetComponent<SEManager>().playAudioClip(audioClip);
            SceneManager.LoadScene(sceneName);
        }
    }
}
