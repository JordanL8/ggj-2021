using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool m_isInteractable;

    public void Unlock()
    {
        m_isInteractable = true;
    }
}
