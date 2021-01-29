using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : SingleSceneSingleton<DayManager>
{
    public delegate void VoidDayDelegate();
    public VoidDayDelegate m_processDayStart;
    public VoidDayDelegate m_processDayEnd;

    public void ProcessDayStart()
    {
        // This event should:
        // 1. Unlock relevant regions.
        // 2. Populate unlocked regions with animals and create rescue events.
        m_processDayStart?.Invoke();
    }

    public void ProcessDayEnd()
    {
        // This event should:
        // 1. Open up some end of day UI
        // 2a. Check how many animals were rescued.
        // 2b. Promote the player if they have rescued enough.
        // 3. Clear out the rescue events and the saved animals.
        // 4. Have a button to start the next day.
        m_processDayEnd?.Invoke();
    }
}
