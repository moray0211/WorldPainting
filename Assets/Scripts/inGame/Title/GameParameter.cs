using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameter : MonoBehaviour
{
    public bool IsReset=false;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
