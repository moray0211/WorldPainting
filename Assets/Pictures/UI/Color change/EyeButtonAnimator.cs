using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeButtonAnimator : MonoBehaviour
{
    public GameObject colorChangeButton;

    private Animator eyeButtonAnimator;
    private Animator colorChangeButtonAnimator;
    bool isOpen = true;
    Color color = Color.white;
    GameObject[] magentas;
    GameObject[] yellows;
    GameObject[] cyans;

    public Switch EyeColor_C;
    public Switch EyeColor_M;
    public Switch EyeColor_Y;

    enum Color
    {
        white,
        magenta,
        cyan,
        yellow
    }

    private void Start()
    {
        eyeButtonAnimator = GetComponent<Animator>();
        colorChangeButtonAnimator = colorChangeButton.GetComponent<Animator>();

        //초기 오브젝트 색별로 구분
        magentas=GameObject.FindGameObjectsWithTag("Magenta"); 
        yellows=GameObject.FindGameObjectsWithTag("Yellow");
        cyans=GameObject.FindGameObjectsWithTag("Cyan");

        //색있는 오브젝트 보이지 않게 하기
        setInvisibleColor(magentas);
        setInvisibleColor(yellows);
        setInvisibleColor(cyans);
        EyeColor_M.setSwitchActive(false);
        EyeColor_C.setSwitchActive(false);
        EyeColor_Y.setSwitchActive(false);

    }

    public void closeOrOpenEyeButton()
    {
        eyeButtonAnimator.ResetTrigger("whiteEyeButtonCloseTrigger");
        eyeButtonAnimator.ResetTrigger("whiteEyeButtonOpenTrigger");
        colorChangeButtonAnimator.ResetTrigger("colorChangeButtonOpenTrigger");
        colorChangeButtonAnimator.ResetTrigger("colorChangeButtonCloseTrigger");

        if (isOpen)
        {
            if (color == Color.white) eyeButtonAnimator.SetTrigger("whiteEyeButtonCloseTrigger");
            else if (color == Color.magenta) eyeButtonAnimator.SetTrigger("magentaEyeButtonCloseTrigger");
            else if (color == Color.cyan) eyeButtonAnimator.SetTrigger("cyanEyeButtonCloseTrigger");
            else if (color == Color.yellow) eyeButtonAnimator.SetTrigger("yellowEyeButtonCloseTrigger");

            colorChangeButtonAnimator.SetTrigger("colorChangeButtonOpenTrigger");
            isOpen = false;

        }
        else
        {
            if (color == Color.white) eyeButtonAnimator.SetTrigger("whiteEyeButtonOpenTrigger");
            else if (color == Color.magenta) eyeButtonAnimator.SetTrigger("magentaEyeButtonOpenTrigger");
            else if (color == Color.cyan) eyeButtonAnimator.SetTrigger("cyanEyeButtonOpenTrigger");
            else if (color == Color.yellow) eyeButtonAnimator.SetTrigger("yellowEyeButtonOpenTrigger");

            colorChangeButtonAnimator.SetTrigger("colorChangeButtonCloseTrigger");
            isOpen = true;
        }

    }

    public void whiteColorChangeButton()
    {
        eyeButtonAnimator.ResetTrigger("whiteEyeButtonOpenTrigger");
        eyeButtonAnimator.SetTrigger("whiteEyeButtonOpenTrigger");

        colorChangeButtonAnimator.ResetTrigger("colorChangeButtonCloseTrigger");
        colorChangeButtonAnimator.SetTrigger("colorChangeButtonCloseTrigger");
        color = Color.white;
        isOpen = true;

        setInvisibleColor(magentas);
        setInvisibleColor(yellows);
        setInvisibleColor(cyans);
        EyeColor_M.setSwitchActive(false);
        EyeColor_C.setSwitchActive(false);
        EyeColor_Y.setSwitchActive(false);
    }

    public void magentaColorChangeButton()
    {
        eyeButtonAnimator.ResetTrigger("magentaEyeButtonOpenTrigger");
        eyeButtonAnimator.SetTrigger("magentaEyeButtonOpenTrigger");

        colorChangeButtonAnimator.ResetTrigger("colorChangeButtonCloseTrigger");
        colorChangeButtonAnimator.SetTrigger("colorChangeButtonCloseTrigger");
        color = Color.magenta;

        setVisibleColor(magentas);
        setInvisibleColor(yellows);
        setInvisibleColor(cyans);
        isOpen = true;

        EyeColor_M.setSwitchActive(true);
        EyeColor_C.setSwitchActive(false);
        EyeColor_Y.setSwitchActive(false);
    }

    public void cyanColorChangeButton()
    {
        eyeButtonAnimator.ResetTrigger("cyanEyeButtonOpenTrigger");
        eyeButtonAnimator.SetTrigger("cyanEyeButtonOpenTrigger");

        colorChangeButtonAnimator.ResetTrigger("colorChangeButtonCloseTrigger");
        colorChangeButtonAnimator.SetTrigger("colorChangeButtonCloseTrigger");
        color = Color.cyan;

        setVisibleColor(cyans);
        setInvisibleColor(yellows);
        setInvisibleColor(magentas);
        isOpen = true;

        EyeColor_M.setSwitchActive(false);
        EyeColor_C.setSwitchActive(true);
        EyeColor_Y.setSwitchActive(false);
    }

    public void yellowColorChangeButton()
    {
        eyeButtonAnimator.ResetTrigger("yellowEyeButtonOpenTrigger");
        eyeButtonAnimator.SetTrigger("yellowEyeButtonOpenTrigger");

        colorChangeButtonAnimator.ResetTrigger("colorChangeButtonCloseTrigger");
        colorChangeButtonAnimator.SetTrigger("colorChangeButtonCloseTrigger");
        color = Color.yellow;

        setVisibleColor(yellows);
        setInvisibleColor(cyans);
        setInvisibleColor(magentas);
        isOpen = true;

        EyeColor_M.setSwitchActive(false);
        EyeColor_C.setSwitchActive(false);
        EyeColor_Y.setSwitchActive(true);
    }
    void setVisibleColor(GameObject[] arr){ //특정 색의 오브젝트가 보이게함
        for(int i=0;i<arr.Length;i++){ 
            if(arr[i]==true) //오브젝트가 Destroy되지 않았다면
               arr[i].SetActive(true);
        }
    }
    void setInvisibleColor(GameObject[] arr){//특정 색의 오브젝트가 보이지 않게 함
        for(int i=0;i<arr.Length;i++){
            if(arr[i]==true) arr[i].SetActive(false);
        }
    }


}
