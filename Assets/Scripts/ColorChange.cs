using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public GameObject BackGroundObject;
    public Sprite BackGround_W;
    public Sprite BackGround_M;
    public Sprite BackGround_C;
    public Sprite BackGround_Y;

    public Switch EyeColor_C;
    public Switch EyeColor_M;
    public Switch EyeColor_Y;

    // Update is called once per frame
    void Update()
    {
        if (EyeColor_C.getSwitchActive())
        {
            BackGroundObject.GetComponent<SpriteRenderer>().sprite = BackGround_C;
        }else if (EyeColor_M.getSwitchActive())
        {
            BackGroundObject.GetComponent<SpriteRenderer>().sprite = BackGround_M;
        }else if (EyeColor_Y.getSwitchActive())
        {
            BackGroundObject.GetComponent<SpriteRenderer>().sprite = BackGround_Y;
        }
        else
        {
            BackGroundObject.GetComponent<SpriteRenderer>().sprite = BackGround_W;
        }
    }
}
