using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : SingleSceneSingleton<StartPoint>
{
    private void OnMouseDown()
    {
        PathClick.instance.startClicked = true;
        PathClick.instance.inLine = true;
        PathClick.instance.mouseDown = true;
        PathClick.instance.isGood = true;
    }
}
