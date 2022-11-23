using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VisualEffectManager : MonoBehaviour
{
    public GameObject FadeInOutCanvas;
    string sceneName;

    public void ChangeSceneFadeInOut(string _sceneName)
    {
        StartCoroutine("FadeInOut");
        sceneName = _sceneName;
    }

    IEnumerator FadeInOut()
    {
        FadeInOutCanvas.GetComponent<FadeInOut>().FadeIn_func();
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<SceneChangeManager>().SceneChange(sceneName);
        yield return new WaitForSeconds(0.5f);
        FadeInOutCanvas.GetComponent<FadeInOut>().FadeOut_func();
    }
}
