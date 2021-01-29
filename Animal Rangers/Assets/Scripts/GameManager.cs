using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        DayManager.Instance.ProcessDayStart();
    }
}
