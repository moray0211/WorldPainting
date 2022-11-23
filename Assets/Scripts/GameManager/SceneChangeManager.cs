using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeManager : MonoBehaviour
{
    public string CurrentScene = "FrontScene";

    /// <summary> 실질적으로 씬을 이동하고, 씬 정보를 저장하는 함수 </summary>
    /// <param name="sceneName"> 이동하고자하는 씬 에셋 이름 </param>
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        CurrentScene = sceneName;
        FindObjectOfType<CharacterVisibleManager>().SetVisibleCharacter(CurrentScene);
    }
}
