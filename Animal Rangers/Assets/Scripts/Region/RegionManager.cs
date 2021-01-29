using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour
{
    public Region[] m_regions;

    public void Awake()
    {
        DayManager.Instance.m_processDayStart += InitialseRegionsForNewDay;
    }

    private void InitialseRegionsForNewDay()
    {
        List<Region> activeRegions = new List<Region>();
        ProgressManager.EJobTitle currentJobTitle = ProgressManager.Instance.CurrentJobTitle;
        for (int i = 0; i < m_regions.Length; i++)
        {
            if (currentJobTitle >= m_regions[i].m_requiredTitle &&
                m_regions[i].m_isLocked)
            {
                m_regions[i].Unlock();
            }

            if(!m_regions[i].m_isLocked)
            {
                activeRegions.Add(m_regions[i]);
            }
        }

        RescueManager.Instance.PopulateRegion(activeRegions[activeRegions.Count - 1]);
    }
}
