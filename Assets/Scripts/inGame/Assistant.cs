using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assistant : MonoBehaviour
{
    void Awake()
    {
        //FindObjectOfType<GameManager>().getInit();
        Debug.Log("Assitant Awake");

        if (!FindObjectOfType<GameManager>().IsStart)
        {
            FindObjectOfType<EyeButtonAnimator>().ColorReArrange();
        }
    }

}
