using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeManager : MonoBehaviour
{
    public string CurrentScene = "FrontScene";

    /// <summary> ���������� ���� �̵��ϰ�, �� ������ �����ϴ� �Լ� </summary>
    /// <param name="sceneName"> �̵��ϰ����ϴ� �� ���� �̸� </param>
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        CurrentScene = sceneName;
        FindObjectOfType<CharacterVisibleManager>().SetVisibleCharacter(CurrentScene);
    }
}
