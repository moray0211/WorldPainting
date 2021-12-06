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
    List<GameObject> magentas;
    List<GameObject> yellows;
    List<GameObject> cyans;

    public enum Color
    {
        white,
        magenta,
        cyan,
        yellow
    }

    private void Start()
    {
        if (FindObjectOfType<GameManager>().IsStart) { 
            eyeButtonAnimator = GetComponent<Animator>();

            Animator[] findanimators = UISingleton.instance.transform.GetComponentsInChildren<Animator>();
            for(int i = 0; i < findanimators.Length; i++)
            {
                if (findanimators[i].name == "ChangeButtons")
                    colorChangeButtonAnimator = findanimators[i];
            }

            magentas=new List<GameObject>();
            yellows=new List<GameObject>();
            cyans=new List<GameObject>();

            ColorReArrange(); //초기 오브젝트 설정
        }
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

        setVisible(color);
        FindObjectOfType<ColorChangeManager>().changeColor();
    }

    public void magentaColorChangeButton()
    {
        eyeButtonAnimator.ResetTrigger("magentaEyeButtonOpenTrigger");
        eyeButtonAnimator.SetTrigger("magentaEyeButtonOpenTrigger");

        colorChangeButtonAnimator.ResetTrigger("colorChangeButtonCloseTrigger");
        colorChangeButtonAnimator.SetTrigger("colorChangeButtonCloseTrigger");
        color = Color.magenta;

        setVisible(color);
        FindObjectOfType<ColorChangeManager>().changeColor();
        isOpen = true;
    }

    public void cyanColorChangeButton()
    {
        eyeButtonAnimator.ResetTrigger("cyanEyeButtonOpenTrigger");
        eyeButtonAnimator.SetTrigger("cyanEyeButtonOpenTrigger");

        colorChangeButtonAnimator.ResetTrigger("colorChangeButtonCloseTrigger");
        colorChangeButtonAnimator.SetTrigger("colorChangeButtonCloseTrigger");
        color = Color.cyan;

        setVisible(color);
        FindObjectOfType<ColorChangeManager>().changeColor();
        isOpen = true;
    }

    public void yellowColorChangeButton()
    {
        eyeButtonAnimator.ResetTrigger("yellowEyeButtonOpenTrigger");
        eyeButtonAnimator.SetTrigger("yellowEyeButtonOpenTrigger");

        colorChangeButtonAnimator.ResetTrigger("colorChangeButtonCloseTrigger");
        colorChangeButtonAnimator.SetTrigger("colorChangeButtonCloseTrigger");
        color = Color.yellow;

        setVisible(color);
        FindObjectOfType<ColorChangeManager>().changeColor();
        isOpen = true;
    }
    
    public void setVisible(Color nowcolor){ //특정 색을 보이게 하고, 나머지 색은 보이지 않게 함
            switch(nowcolor){
                case Color.white :
                    setInvisibleColor(yellows);
                    setInvisibleColor(cyans);
                    setInvisibleColor(magentas);
                    break;
                case Color.magenta :
                    setVisibleColor(magentas);
                    setInvisibleColor(yellows);
                    setInvisibleColor(cyans);
                    break;
                case Color.cyan :
                    setVisibleColor(cyans);
                    setInvisibleColor(yellows);
                    setInvisibleColor(magentas);
                    break;
                case Color.yellow : 
                    setVisibleColor(yellows);
                    setInvisibleColor(cyans);
                    setInvisibleColor(magentas);
                    break;
        }
    }

    void setVisibleColor(List<GameObject> arr){ //특정 색의 오브젝트가 보이게함
        for(int i=0;i<arr.Count;i++){
            if(arr[i]==true) {//오브젝트가 Destroy되지 않았다면
                arr[i].SetActive(true);
            }
        }
    }

    void setInvisibleColor(List<GameObject> arr){//특정 색의 오브젝트가 보이지 않게 함
        for(int i=0;i<arr.Count;i++){
            if (arr[i]==true){
                arr[i].SetActive(false);
            }
                
        }
    }

    public void ColorReArrange()
    {
        FindObjectOfType<ColorChangeManager>().changeColor(); //배경색 다시적용
        setVisibleColor(yellows);
        setVisibleColor(cyans);
        setVisibleColor(magentas);
        magentas.Clear();
        cyans.Clear();
        yellows.Clear();

        foreach (GameObject magen in GameObject.FindGameObjectsWithTag("Magenta"))
        {
            if (magen != false && magentas.Find(o => o.name == magen.name) == false)
            {
                magentas.Add(magen);
            }
        }
        foreach (GameObject cyan in GameObject.FindGameObjectsWithTag("Cyan"))
        {
            if (cyan == true && cyans.Find(o => o.name == cyan.name) == false)
            {
                cyans.Add(cyan);
            }
        }

        foreach (GameObject yellow in GameObject.FindGameObjectsWithTag("Yellow"))
        {
            if (yellows.Find(o => o.name == yellow.name) == false)
            {
                yellows.Add(yellow);
            }
        }
        setVisible(color);
    }

    public void deleteObject(string pname,string tag){
        if(tag=="Magenta"){
            GameObject tem = magentas.Find(o => o.name == pname);
            magentas.Remove(tem);

            tem = magentas.Find(o => o.name.Contains(pname));
            if (tem==true){
                magentas.Remove(magentas.Find(o => o.name==tem.name));
                Destroy(tem);
            }
        }
        else if (tag == "Cyan")
        {
            GameObject tem=cyans.Find(o => o.name==pname);
            cyans.Remove(tem);

            tem = cyans.Find(o => o.name.Contains(pname));
            if(tem==true){
                cyans.Remove(cyans.Find(o => o.name==tem.name));
                Destroy(tem);
            }
        }
        else if (tag == "Yellow")
        {
            GameObject tem = yellows.Find(o => o.name == pname);
            yellows.Remove(tem);

            tem = yellows.Find(o => o.name.Contains(pname));
            if (tem==true){
                yellows.Remove(yellows.Find(o => o.name==tem.name));
                Destroy(tem);
            }
        }
    }

    public int getcolor(){
        switch(color){
            case Color.white :
                return 0;
            case Color.magenta :
                return 1;
            case Color.cyan :
                return 2;
            case Color.yellow : 
                return 3;
            default : return -1;
        }
    }
}
