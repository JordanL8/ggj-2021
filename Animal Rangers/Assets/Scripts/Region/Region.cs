using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public Vector3[] m_spawnPoints;
    public Obstacle m_regionBlockingObstacle;

    public ProgressManager.EJobTitle m_requiredTitle;

    public bool m_isLocked = true;


    public void Unlock()
    {
        if(!m_regionBlockingObstacle.m_isInteractable)
        {
            m_regionBlockingObstacle.Unlock();
        }
    }
}
