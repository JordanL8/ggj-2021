using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameHook : MonoBehaviour
{
    public MiniGame miniGameRef;
    public delegate void OnCompleteDelegate();
    public OnCompleteDelegate m_onComplete;


    public Transform miniGameRect;
    public Transform m_target;

    public void Update()
    {
        float distance = Vector3.Distance(m_target.position, miniGameRect.position);
        if (distance < 10)
        {
            SetUpMiniGame();
        }
       
    }

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
