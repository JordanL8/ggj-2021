using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public delegate void OnCompleteDelegate();
    public OnCompleteDelegate m_onComplete;
    public GameObject miniGameObj;

    protected virtual void Complete()
    {
        Object.Destroy(miniGameObj);
        m_onComplete?.Invoke();
    }
}
