using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathClick : SingleSceneSingleton<PathClick>
{
    public bool mouseDown = false;
    public bool inLine = false;
    public bool startClicked = false;
    public bool isGood = false;
        
    private void OnMouseDown()  {mouseDown = true;}

    private void Update()
    {
        //Debug.Log(isGood);isGood && 

        if (Input.GetMouseButtonUp(0)) {mouseDown = false;}

        // Failed
        if (isGood && (!mouseDown || !inLine))
        {
            StartPoint.instance.GetComponent<Image>().color = Color.green;
            StartPoint.instance.finish.gameObject.GetComponent<Image>().color = Color.grey;
            GetComponent<SpriteRenderer>().color = Color.red;
            LeanTween.value(gameObject, Color.red, Color.white, 1.5f).setOnUpdateColor(UpdateColour);

            mouseDown = false;
            inLine = false;
            startClicked = false;
            isGood = false;
        }
    }

    void UpdateColour(Color colour)
    {
        GetComponent<SpriteRenderer>().color = colour;
    }
}
