using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisibleManager : MonoBehaviour
{
    public GameObject MagenObject;
    public GameObject YellowObject;
    public GameObject CyanObject;

    public bool[] IsActive = { false, false, false }; //MYC ����

    public void SetActiveCharacter(int key)
    {
        IsActive[key] = true;
    }

    /// <summary>
    /// �� �̵� �ÿ� ���� �´� ĳ���Ͱ� ���̰� �ϴ� �Լ�
    /// </summary>
    /// <param name="CurrentScene"> ���� �̵��� �� ���� �̸� </param>
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
