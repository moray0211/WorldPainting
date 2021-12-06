using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Safer_BtnTrigger : MonoBehaviour
{
    public enum BtnType
    {
        Reset,
        Submit,
        num
    }

    public BtnType mytype;
    public string mynumber;

    public void BtnInput_Tirgger()
{
    switch (mytype)
    {
        case BtnType.Reset:
            FindObjectOfType<Safer_password>().resetInputPassword();
            break;
        case BtnType.Submit:
            FindObjectOfType<Safer_password>().CheckIsItCorrect();
            break;
        case BtnType.num:
            FindObjectOfType<Safer_password>().addNumberToPassword(mynumber);
            break;
    }
}
}
