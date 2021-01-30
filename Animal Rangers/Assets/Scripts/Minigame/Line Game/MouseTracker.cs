using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : SingleSceneSingleton<MouseTracker>
{
    public Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = gameCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        newPos.z = transform.position.z;
        transform.position = newPos;

    }
        
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Path1")
            PathClick.instance.inLine = false;
    }
}
