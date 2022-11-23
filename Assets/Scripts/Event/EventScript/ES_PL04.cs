using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES_PL04 : IEventScript
{
    public override void StartEvent()
    {
        FindObjectOfType<ColorChangeManager>().UnLockColor(2);
    }

    public override void EndEvent()
    {
    }
}
