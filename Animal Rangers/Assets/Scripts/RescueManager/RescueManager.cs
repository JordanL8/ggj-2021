using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueManager : SingleSceneSingleton<RescueManager>
{
    public int[] m_numbersPerDay;

    public float m_gibblesPerRescue = 20.0f;



    public void PopulateRegions(List<Region> activeRegions)
    {
        if(DayManager.Instance.CurrentDay - 1 < m_numbersPerDay.Length)
        {
            int numberOfFloofsToday = m_numbersPerDay[DayManager.Instance.CurrentDay - 1] - 1;

            AddFloofToRegion(activeRegions[activeRegions.Count - 1]);

            while(numberOfFloofsToday > 0)
            {
                AddFloofToRegion(activeRegions[Random.Range(0, activeRegions.Count)]);
            }
        }
    }

    public void AddFloofToRegion(Region curRegion)
    {
        Floof floofToAdd = FloofManager.Instance.GetRandomFloof();
    }



    public void GetFloof(Floof floof)
    {
        floof.StartFollowing();
    }

    public void RescueFloof(Floof floof)
    {
        GibbleManager.Instance.Credit(m_gibblesPerRescue);
    }
}
