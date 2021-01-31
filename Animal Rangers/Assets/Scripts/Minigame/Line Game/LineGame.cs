using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGame : SingleSceneSingleton<LineGame>
{
    public GameObject[] paths;

    private void Start()
    {
        GameObject activePath = Instantiate(paths[Random.Range(0, paths.Length)], this.transform);
        
        activePath.AddComponent<PathClick>();
        activePath.AddComponent<PolygonCollider2D>();

        int flipX = Random.Range(0, 2);
        int flipY = Random.Range(0, 2);

        Vector3 startPos = transform.GetChild(1).GetChild(0).localPosition;
        Vector3 endPos = transform.GetChild(1).GetChild(1).localPosition;

        if (flipX == 1 && flipY == 1)
        {
            activePath.transform.Rotate(180f, 180f, 0, Space.Self);

            activePath.transform.GetChild(0).transform.localPosition = new Vector3(endPos.x, endPos.y, -0.2f);
            activePath.transform.GetChild(1).transform.localPosition = new Vector3(startPos.x, startPos.y, -0.2f);
        }
        else if (flipX == 1)
        {
            activePath.transform.Rotate(0, 180f, 0, Space.Self);

            activePath.transform.GetChild(0).transform.localPosition = new Vector3(endPos.x, endPos.y, 0.2f);
            activePath.transform.GetChild(1).transform.localPosition = new Vector3(startPos.x, startPos.y, 0.2f);
        }
        else if (flipY == 1)
        {
            activePath.transform.Rotate(180f, 0, 0, Space.Self);

            activePath.transform.GetChild(0).transform.localPosition = new Vector3(startPos.x, startPos.y, 0.2f);
            activePath.transform.GetChild(1).transform.localPosition = new Vector3(endPos.x, endPos.y, 0.2f);
        }

        Rigidbody2D rb = activePath.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;        
    }

    void Update()
    {

        /* ---- FOR TESTING ---- */
        if (Input.GetKeyDown(KeyCode.L))
            PlayerMovement.instance.Deactivate();
        else if (Input.GetKeyDown(KeyCode.K))
            PlayerMovement.instance.Activate();
        /* ---- FOR TESTING ---- */
        
    }

}
