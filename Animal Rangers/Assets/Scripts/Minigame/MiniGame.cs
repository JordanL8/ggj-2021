using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public delegate void OnCompleteDelegate();
    public OnCompleteDelegate m_onComplete;


    protected virtual void Complete()
    {
        m_onComplete?.Invoke();
    }
}
