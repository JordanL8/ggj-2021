using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EJobTitle
{
    eParkTrainee,
    eParkRookie,
    eParkRanger,
    eParkSupervisor
}

public static class EJobTitleExtensions
{
    public static string ToFormattedString(this EJobTitle jobtitle)
    {
        switch (jobtitle)
        {
            case EJobTitle.eParkTrainee:
            {
                return "Park Trainee";
            }
            case EJobTitle.eParkRookie:
            {
                return "Park Rookie";
            }
            case EJobTitle.eParkRanger:
            {
                return "Park Ranger";
            }
            case EJobTitle.eParkSupervisor:
            {
                return "Park Supervisor";
            }
        }
        return "";
    }
}
public class ProgressManager : SingleSceneSingleton<ProgressManager>
{
    

    private int m_floofsSavedToday = 0;
    private int m_floofsSaved = 0;
    public int[] m_promotionThresholds = new int[3];

    public EJobTitle CurrentJobTitle { get; set; }

    public void Start()
    {
        DayManager.Instance.m_processDayStart += ProcessStartOfDay;
        DayManager.Instance.m_processDayEnd += ProcessEndOfDayProgress;
    }

    public void RegisterNewRescue()
    {
        m_floofsSavedToday++;
    }

    private void PromotePlayer()
    {
        if((int)CurrentJobTitle < ((int)EJobTitle.eParkSupervisor))
        {
            CurrentJobTitle = (EJobTitle)((int)CurrentJobTitle + 1);
        }
        else
        {
            Debug.LogWarning("Did not promote player, player is at max level.");
        }
    }

    private void ProcessStartOfDay()
    {
        m_floofsSavedToday = 0;
    }

    private void ProcessEndOfDayProgress()
    {
        m_floofsSaved += m_floofsSavedToday;
        bool playerPromoted = false;
        if(CurrentJobTitle != EJobTitle.eParkSupervisor)
        {
            if(m_floofsSaved >= m_promotionThresholds[(int)CurrentJobTitle])
            {
                PromotePlayer();
                playerPromoted = true;
            }
        }
        string progressNotification = $"Hey, you saved <color=green>{m_floofsSavedToday}</color> floofs today! You've saved <color=green>{m_floofsSaved}</color> overall! Nice work!";
        if(playerPromoted)
        {
            progressNotification += $"<br>You have been promoted to <color=blue>{CurrentJobTitle.ToFormattedString()}</color>. You can now enter more biomes in the park.";
        }
        NotificationManager.Instance.DisplayNotification(progressNotification, true, DayManager.Instance.ProcessDayStart);
    }
}
