using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeManager : MonoBehaviour
{
    public GameObject[] EyeButtonMCY;
    bool[] EyeButtonLock = { true, true, true }; //초기 시야 잠금
    GameObject[] changes;
    int color=0;
    void Start()
    {
        for (int i = 0; i < 3; i++) {
            if (EyeButtonLock[i]) EyeButtonMCY[i].SetActive(false);
            else EyeButtonMCY[i].SetActive(true);
        }

        color=FindObjectOfType<EyeButtonAnimator>().getcolor();
        changes=GameObject.FindGameObjectsWithTag("Change");
        changeColor();
    }

    public void changeColor(){
        color=FindObjectOfType<EyeButtonAnimator>().getcolor();
        setColor();
    }

    void setColor(){
        changes=GameObject.FindGameObjectsWithTag("Change");
        for(int i=0;i<changes.Length;i++){
            changes[i].GetComponent<ColorChangeObject>().changecolor(color);
        }
    }

    public void UnLockColor(int colorNum)
    { //색깔 잠금 해제 (MCY : 012)
        EyeButtonLock[colorNum] = true;
    }

}
