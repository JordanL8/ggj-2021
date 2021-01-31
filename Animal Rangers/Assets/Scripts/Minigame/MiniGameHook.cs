using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameHook : MonoBehaviour
{
    public MiniGame miniGameRef;
    public delegate void OnCompleteDelegate();
    public OnCompleteDelegate m_onComplete;


    public void SetUpMiniGame()
    {
        miniGameRef.gameObject.SetActive(true);
        miniGameRef.StartMiniGame(this);
    }

    public void Complete()
    {
        m_onComplete?.Invoke();
    }
}
