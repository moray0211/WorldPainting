using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseObjcet : MonoBehaviour
{ //닫을 오브젝트
    public GameObject changeobj; //변경할 오브젝트(보통 맵 전체)
    public GameObject[] notshow; //화면을 열었을 때 보이지 않는 오브젝트

    public void setopen(){ //줌인, 서랍을 열 때 실행되는 함수
        if(changeobj==true) changeobj.SetActive(false);
        FindObjectOfType<EyeButtonAnimator>().ColorReArrange();
        setInactivechild();
    }

    public void setclose(){ //줌아웃
        changeobj.SetActive(true);
        setactivechild(); //자식들까지 active 시켜준다 (색상 적용을 위해)
        FindObjectOfType<EyeButtonAnimator>().ColorReArrange();
        this.gameObject.SetActive(false);
    }

    void setactivechild(){ //자식 오브젝트까지 모두 active 상태로 만드는 함수
        for(int i=0;i<changeobj.transform.childCount;i++){
            changeobj.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void setInactivechild(){
        for(int i=0;i<notshow.Length;i++){
            notshow[i].SetActive(false);
        }
    }
}
