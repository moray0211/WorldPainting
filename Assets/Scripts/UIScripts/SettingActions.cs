using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingActions : MonoBehaviour
{
    public GameObject Settingcanvas;
    public GameObject UI;

    public void ResumeGame()
    {
        Settingcanvas.SetActive(false);
    }

    public void Gotitle()
    {
        FindObjectOfType<DataManager>().SaveGameData();
        SceneManager.LoadScene("TitleScene");
        Settingcanvas.SetActive(false);
    }
}
