using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public string m_name;
    public Transform[] m_spawnPoints;
    public Obstacle[] m_obstacles;
    public GameObject m_blocker;

    public ProgressManager.EJobTitle m_requiredTitle;

    public bool m_isLocked = true;


    // API
    public void InitialiseForNewDay()
    {
        
    }

    public void Unlock()
    {
        m_blocker.SetActive(false);
        m_isLocked = false;
    }


}
