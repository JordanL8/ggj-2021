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
