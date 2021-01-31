using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGame : MiniGame
{
    public DragDrop[] dragItems;
    private bool allMoved = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < dragItems.Length; i++)
        {
            if (!dragItems[i].moved)
            {
                allMoved = false;
                break;
            }
            else
            {
                allMoved = true;
            }
        }
        if (allMoved)
        {
            base.Complete();
            Debug.Log("DNE");
        }
    }
}
