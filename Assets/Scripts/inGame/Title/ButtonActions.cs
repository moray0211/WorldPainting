using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void StartNewGame()
    {
        FindObjectOfType<GameParameter>().IsReset = true;
        SceneManager.LoadScene("LoadingScene");
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif
    }

}
