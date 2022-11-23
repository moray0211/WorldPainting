using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES_PL05 :IEventScript
{
    public override void StartEvent()
    {
        FindObjectOfType<ColorChangeManager>().UnLockColor(0);
    }

    public override void EndEvent()
    {
    }
}
