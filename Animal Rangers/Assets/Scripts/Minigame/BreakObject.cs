using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class BreakObject : MiniGame
{
    private int breakHits = 5;
    public Button[] breakPoints;
    private Button temp;
    public void breakObj()
    {
        breakHits -= 1;
    }

    void Start()
    {
        breakHits = Random.Range(2, 6);
        Debug.Log("hits" + breakHits);


        int rnd = Random.Range(1, breakPoints.Length);
         
        for (int i = 0; i < breakHits; i++)
        {
            int randomIndex = Random.Range(i, breakPoints.Length);
            temp = breakPoints[randomIndex];
            breakPoints[randomIndex] = breakPoints[i];
            breakPoints[i] = temp;
            breakPoints[i].gameObject.SetActive(true);
        }
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
