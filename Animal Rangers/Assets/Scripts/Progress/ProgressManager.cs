using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : SingleSceneSingleton<ProgressManager>
{
    public enum EJobTitle
    {
        eParkTrainee,
        eParkRookie,
        eParkRanger,
        eParkSupervisor,
        COUNT
    }

    public EJobTitle CurrentJobTitle { get; set; }

    public void PromotePlayer()
    {
        if((int)CurrentJobTitle < ((int)EJobTitle.COUNT - 1))
        {
            CurrentJobTitle = (EJobTitle)((int)CurrentJobTitle + 1);
        }
        else
        {
            Debug.LogWarning("Did not promote player, player is at max level.");
        }
    }
}
