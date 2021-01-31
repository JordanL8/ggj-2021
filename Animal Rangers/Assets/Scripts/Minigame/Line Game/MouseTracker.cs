using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : SingleSceneSingleton<MouseTracker>
{
    public Camera gameCamera;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = gameCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        newPos.z = transform.position.z;
        transform.position = newPos;

    }
        
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            PathClick.instance.inLine = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            if (PathClick.instance.mouseDown && PathClick.instance.inLine && PathClick.instance.startClicked)
            {
                Debug.Log("Finish");
                PathClick.instance.GetComponent<SpriteRenderer>().color = Color.green;
                LineGame.instance.gameObject.SetActive(false);
            }
        }        
    }
}
