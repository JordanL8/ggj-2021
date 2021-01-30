using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathClick : SingleSceneSingleton<PathClick>
{
    public bool mouseDown = false;
    public bool inLine = false;
        
    private void OnMouseDown()
    {
        mouseDown = true;
    }

    private void OnMouseUp()
    {
        mouseDown = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MousePos")
            Debug.Log("Inside");        
    }
}
