using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.white, 0.005f);
            mouseDown = false;
            inLine = false;
            startClicked = false;
            isGood = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MousePos" && startClicked && mouseDown && inLine)
        {

        }
    }
}
