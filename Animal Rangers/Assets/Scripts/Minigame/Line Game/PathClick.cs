using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathClick : SingleSceneSingleton<PathClick>
{
    public bool mouseDown = false;
    public bool inLine = false;
    public bool startClicked = false;
        
    private void OnMouseDown()  {mouseDown = true;}

    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) {mouseDown = false;}

        // Failed
        if (!mouseDown || !inLine)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.white, 0.005f);
            mouseDown = false;
            inLine = false;
            startClicked = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MousePos" && startClicked && mouseDown && inLine)
        {

        }
    }
}
