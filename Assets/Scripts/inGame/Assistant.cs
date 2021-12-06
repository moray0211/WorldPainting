using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assistant : MonoBehaviour
{
    void Awake()
    {
        //FindObjectOfType<GameManager>().getInit();
        if (!FindObjectOfType<GameManager>().IsStart)
        {
            FindObjectOfType<EyeButtonAnimator>().ColorReArrange();
        }
    }

}
