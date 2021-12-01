using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Safer_password : MonoBehaviour
{
    public string AnswerPassword;
    public string nowPassword;
    public Text PasswordText;

    void Start()
    {
        resetInputPassword();
    }

    void Update()
    {
        PasswordText.text = nowPassword;
    }
    public void CheckIsItCorrect()
    {
        if (nowPassword.Length == 4)
        {
            if (nowPassword == AnswerPassword)
            {
                Debug.Log("��й�ȣ ����");
            }
            else
            {
                resetInputPassword();
                Debug.Log("��й�ȣ ����");
            }
        }
    }

    public void addNumberToPassword(string num)
    {
        if (nowPassword.Length < 4)
        {
            nowPassword= nowPassword.Insert(nowPassword.Length, num);
        }else
        {
            Debug.Log("��й�ȣ �ʰ�");
        }
    }
    
    public void resetInputPassword()
    {
        nowPassword = "";
    }
}
