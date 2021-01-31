using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGame : MiniGame
{
    public DragDrop[] dragItems;
    private bool allMoved = false;
    public List<Vector3> vectorPos;
    // Start is called before the first frame update

    public void Start()
    {
        for(int i = 0; i < dragItems.Length; i++)
        {
            vectorPos.Add(dragItems[i].transform.position);
        }
    }
    public override void StartMiniGame(MiniGameHook miniGameHook)
    {
        base.StartMiniGame(miniGameHook);

        for (int i = 0; i < vectorPos.Count; i++)
        {
            dragItems[i].transform.position = vectorPos[i];
            dragItems[i].moved = false;
        }
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
        }
    }
}
