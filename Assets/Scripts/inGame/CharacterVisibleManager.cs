using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisibleManager : MonoBehaviour
{
    public GameObject MagenObject;
    public GameObject YellowObject;
    public GameObject CyanObject;

    public bool[] IsActive = { false, false, false }; //MYC 순서

    public void SetActiveCharacter(int key)
    {
        IsActive[key] = true;
    }

    /// <summary>
    /// 씬 이동 시에 씬에 맞는 캐릭터가 보이게 하는 함수
    /// </summary>
    /// <param name="CurrentScene"> 현재 이동된 씬 에셋 이름 </param>
    public void SetVisibleCharacter(string CurrentScene)
    {
        MagenObject.SetActive(false);
        YellowObject.SetActive(false);
        CyanObject.SetActive(false);

        switch (CurrentScene)
        {
            case "FrontScene":
                if(IsActive[0]) MagenObject.SetActive(true);
                break;
            case "LibraryScene":
                if (IsActive[1]) YellowObject.SetActive(true);
                break;
            case "BathroomScene":
                if (IsActive[2]) CyanObject.SetActive(true);
                break;
            default : break;
        }
    }
}
