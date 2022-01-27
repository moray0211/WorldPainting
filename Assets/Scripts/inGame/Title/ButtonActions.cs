using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void StartNewGame()
    {
        FindObjectOfType<GameParameter>().IsReset = true;
        SceneManager.LoadScene("kitchenScene");
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene("kitchenScene");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // ���ø����̼� ����
        #endif
    }

}
