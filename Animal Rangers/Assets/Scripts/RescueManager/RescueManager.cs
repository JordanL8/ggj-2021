using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueManager : SingleSceneSingleton<RescueManager>
{
    public int m_startNumber = 2;
    private int m_numberOfFloofsToday;

    public float m_gibblesPerRescue = 20.0f;

    private List<Floof> spawnedFloofs = new List<Floof>();

    private Floof m_currentFloof = null;
    public Floof CurrentFloof => m_currentFloof;

    protected override void Awake()
    {
        m_numberOfFloofsToday = m_startNumber;
    }

    public void PopulateRegions(List<Region> activeRegions)
    {
        int todaysFloofs = m_numberOfFloofsToday;
        AddFloofToRegion(activeRegions[activeRegions.Count - 1]);
        todaysFloofs--;

        while(todaysFloofs > 0)
        {
            AddFloofToRegion(activeRegions[Random.Range(0, activeRegions.Count)]);
            todaysFloofs--;
        }

        DeactivateExtraFloofs();
        m_currentFloof = spawnedFloofs[0];
        NotificationManager.Instance.DisplayNotification(m_currentFloof.m_floofType, m_currentFloof.MyRegion.m_name);
        m_numberOfFloofsToday++;
    }

    public void AddFloofToRegion(Region curRegion)
    {
        Floof floofToAdd = FloofManager.Instance.GetRandomFloof();
        Transform[] spawnPoints = curRegion.m_spawnPoints;

        // Instantiate the floof and chuck it somewhere       

        Floof newFloof = FloofSpawner.Instance.SpawnFloofs(floofToAdd, spawnPoints);
        newFloof.SetRegion(curRegion);
        spawnedFloofs.Add(newFloof);
    }

    public void DeactivateExtraFloofs()
    {
        for (int i = 1; i < spawnedFloofs.Count; i++)
        {
            spawnedFloofs[i].gameObject.SetActive(false);
        }
    }


    public void RescueFloofComplete()
    {
        GibbleManager.Instance.Credit(m_gibblesPerRescue);
        ProgressManager.Instance.RegisterNewRescue();

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
            m_currentFloof = spawnedFloofs[0];
            NotificationManager.Instance.DisplayNotification(m_currentFloof.m_floofType, m_currentFloof.MyRegion.m_name);
            DeactivateExtraFloofs();
        }
    }
}
