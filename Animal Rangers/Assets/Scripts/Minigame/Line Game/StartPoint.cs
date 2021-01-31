using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPoint : SingleSceneSingleton<StartPoint>
{
    public Transform finish;

    private void Start()
    {
        finish = gameObject.transform.parent.GetChild(1);
    }

    private void OnMouseDown()
    {
        PathClick.instance.startClicked = true;
        PathClick.instance.inLine = true;
        PathClick.instance.mouseDown = true;
        PathClick.instance.isGood = true;

        PathClick.instance.GetComponent<SpriteRenderer>().color = Color.white;
        gameObject.GetComponent<Image>().color = Color.grey;
        finish.GetComponent<Image>().color = Color.green;
    }
}
