using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    public Button[] buttons;
    public Text[] settings;
    public GameObject topCanvas;
    int nownum = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            topCanvas.SetActive(false);
        }else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            nownum--;
            if (nownum <0 ) nownum = settings.Length-1;
            MoveBGToHere(nownum);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            nownum++;
            if (nownum >= settings.Length) nownum = 0;
            MoveBGToHere(nownum);
        }else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (nownum == 0) FindObjectOfType<SettingActions>().ResumeGame();
            else if (nownum == 1) FindObjectOfType<SettingActions>().Gotitle();
        }
    }

    public void MoveBGToHere(int place)
    {
        for (int i = 0; i < settings.Length; i++)
        {
            if (i == place)
            {
                settings[i].color = Color.white;
                buttons[i].image.sprite = buttons[place].spriteState.highlightedSprite;
                buttons[i].image.color = new Color(0, 0, 0, 255);
            }
            else
            {
                buttons[i].image.sprite = null;
                buttons[i].image.color =new Color(0,0,0,0.0f);
                settings[i].color = Color.black;
            }
        }
        
    }

    
}
