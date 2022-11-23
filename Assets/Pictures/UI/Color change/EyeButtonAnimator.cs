using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        if (FindObjectOfType<GameManager>().IsStart)
        {
            eyeButtonAnimator = GetComponent<Animator>();

            Animator[] findanimators = UISingleton.instance.transform.GetComponentsInChildren<Animator>();
            for (int i = 0; i < findanimators.Length; i++)
            {
                if (findanimators[i].name == "ChangeButtons")
                    colorChangeButtonAnimator = findanimators[i];
            }

        }

        eyeButtonAnimator = GetComponent<Animator>();
        colorChangeButtonAnimator = colorChangeButton.GetComponent<Animator>();

        //초기 오브젝트 색별로 구분
        magentas=GameObject.FindGameObjectsWithTag("Magenta").ToList(); 
        yellows=GameObject.FindGameObjectsWithTag("Yellow").ToList();
        cyans=GameObject.FindGameObjectsWithTag("Cyan").ToList();

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

        setVisible(color);
        FindObjectOfType<ColorChangeManager>().changeColor();
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

        setVisible(color);
        FindObjectOfType<ColorChangeManager>().changeColor();
        isOpen = true;

        EyeColor_M.setSwitchActive(false);
        EyeColor_C.setSwitchActive(false);
        EyeColor_Y.setSwitchActive(true);
    }
    
    void setVisible(Color nowcolor){ //특정 색을 보이게 하고, 나머지 색은 보이지 않게 함
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

    //색상 리스트 재설정하는 함수
    public void ColorReArrange()
    {
        FindObjectOfType<ColorChangeManager>().changeColor(); //배경색 다시적용
        setVisibleColor(yellows); //모든 색상을 보이게 한 후 리스트를 재설정해줌
        setVisibleColor(cyans);
        setVisibleColor(magentas);
        magentas.Clear();
        cyans.Clear();
        yellows.Clear();

        foreach (GameObject magen in GameObject.FindGameObjectsWithTag("Magenta")) //마젠타 태그를 가진 오브젝트 모두 저장
        {
            if (magen != false && magentas.Find(o => o.name == magen.name) == false&&magen.GetComponent<ItemPickup>()==true)
            {
                if (magen.GetComponent<ItemPickup>().item.getItemDestory() == false) magentas.Add(magen);  
                else Destroy(magen); //그 오브젝트가 아이템을 이미 얻고 삭제될 오브젝트라면 삭제해줌
            }
        }
        foreach (GameObject cyan in GameObject.FindGameObjectsWithTag("Cyan"))
        {
            if (cyan == true && cyans.Find(o => o.name == cyan.name) == false && cyan.GetComponent<ItemPickup>() == true)
            {
                if (cyan.GetComponent<ItemPickup>().item.getItemDestory() == false) cyans.Add(cyan);
                else Destroy(cyan);
            }
        }

        foreach (GameObject yellow in GameObject.FindGameObjectsWithTag("Yellow"))
        {
            if (yellows.Find(o => o.name == yellow.name) == false && yellow.GetComponent<ItemPickup>() == true)
            {
                if (yellow.GetComponent<ItemPickup>().item.getItemDestory() == false) yellows.Add(yellow);
                else Destroy(yellow);
            }
        }
        setVisible(color);
    }


    //특정 아이템을 획득하는 등 삭제해야 할 때, 그 아이템의 이름 pname과 색상 tag를 받아 색상 리스트에서 삭제해줌
    public void deleteObject(string pname,string tag){
        if(tag=="Magenta"){ //색상 마젠타라면
            GameObject tem = magentas.Find(o => o.name == pname); //리스트에서 그 오브젝트를 찾아 삭제
            magentas.Remove(tem);
            Destroy(tem);

            //그 아이템의 이름을 가진 오브젝트가 여러 개일 수 있음 (확대, 축소 시의 오브젝트 분리로 인함)
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
            Destroy(tem);
            tem = cyans.Find(o => o.name.Contains(pname));
            if (tem==true){
                cyans.Remove(cyans.Find(o => o.name==tem.name));
                Debug.Log(tem.name + "삭제");
                Destroy(tem); 
            }
        }
        else if (tag == "Yellow")
        {
            GameObject tem = yellows.Find(o => o.name == pname);
            yellows.Remove(tem);
            Destroy(tem);
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
