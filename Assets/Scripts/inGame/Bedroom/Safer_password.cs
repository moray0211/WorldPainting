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
                Debug.Log("비밀번호 정답");
            }
            else
            {
                resetInputPassword();
                Debug.Log("비밀번호 오답");
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
            Debug.Log("비밀번호 초과");
        }
    }
    
    public void resetInputPassword()
    {
        nowPassword = "";
    }
}
