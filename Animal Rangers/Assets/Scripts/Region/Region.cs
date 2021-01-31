using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public string m_name;
    public Transform[] m_spawnPoints;
    public Obstacle[] m_obstacles;
    public GameObject m_blocker;

    public EJobTitle m_requiredTitle;

    public bool m_isLocked = true;

    public RadarManager.BiomeState floofBiome;

    // API
    public void InitialiseForNewDay()
    {
        for (int i = 0; i < m_obstacles.Length; i++)
        {
            m_obstacles[i].gameObject.SetActive(true);
        }
    }

    public void Unlock()
    {
        m_blocker.SetActive(false);
        m_isLocked = false;
    }


}
