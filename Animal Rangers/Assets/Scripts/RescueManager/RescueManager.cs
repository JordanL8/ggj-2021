using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueManager : SingleSceneSingleton<RescueManager>
{
    public int[] m_numbersPerDay;

    public float m_gibblesPerRescue = 20.0f;

    private List<Floof> spawnedFloofs = new List<Floof>();


    /* ---- FOR TESTING ---- */
    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
            RescueFloofComplete();
    }
    /* ---- FOR TESTING ---- */


    public void PopulateRegions(List<Region> activeRegions)
    {
        if(DayManager.Instance.CurrentDay - 1 < m_numbersPerDay.Length)
        {
            int numberOfFloofsToday = m_numbersPerDay[DayManager.Instance.CurrentDay - 1] - 1;

            AddFloofToRegion(activeRegions[activeRegions.Count - 1]);

            while(numberOfFloofsToday > 0)
            {
                AddFloofToRegion(activeRegions[Random.Range(0, activeRegions.Count)]);
                numberOfFloofsToday--;
            }
        }

        DeactivateExtraFloofs();
    }

    public void AddFloofToRegion(Region curRegion)
    {
        Floof floofToAdd = FloofManager.Instance.GetRandomFloof();
        Transform[] spawnPoints = curRegion.m_spawnPoints;

        // Instantiate the floof and chuck it somewhere       
        spawnedFloofs.Add(FloofSpawner.Instance.SpawnFloofs(floofToAdd, spawnPoints));
    }

    public void DeactivateExtraFloofs()
    {
        for (int i = 1; i < spawnedFloofs.Count; i++)
        {
            spawnedFloofs[i].gameObject.SetActive(false);
        }
    }

    public void GetFloof(Floof floof)
    {
        floof.StartFollowing();
    }

    public void RescueFloof(Floof floof)
    {
        GibbleManager.Instance.Credit(m_gibblesPerRescue);
    }

    public void RescueFloofComplete()
    {
        // Last floof rescued
        if (spawnedFloofs.Count == 1)
        {
            Destroy(spawnedFloofs[0].gameObject);
            spawnedFloofs.Clear();

            DayManager.Instance.ProcessDayEnd();
        }
        else
        {
            Destroy(spawnedFloofs[0].gameObject);
            spawnedFloofs.RemoveAt(0);

            // Activate next floof
            spawnedFloofs[0].gameObject.SetActive(true);
            DeactivateExtraFloofs();
        }
    }
}
