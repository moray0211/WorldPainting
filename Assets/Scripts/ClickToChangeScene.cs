using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToChangeScene : ItemInteractable
{
    public string sceneName;

    public override void Interact()
    {
        base.Interact();
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
