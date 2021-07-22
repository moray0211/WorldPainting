using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeManager : MonoBehaviour
{
    GameObject[] changes;
    int color=0;
    void Start()
    {
        color=FindObjectOfType<EyeButtonAnimator>().getcolor();
        changes=GameObject.FindGameObjectsWithTag("Change");
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

}
