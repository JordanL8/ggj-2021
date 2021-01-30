using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MiniGame
{
    private int breakHits = 5;
    public GameObject[] breakPoints; 

    public void breakObj()
    {
        breakHits -= 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        breakHits = Random.Range(1, 6);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(breakHits <= 0)
        {
            base.Complete();
        }
    }
}
