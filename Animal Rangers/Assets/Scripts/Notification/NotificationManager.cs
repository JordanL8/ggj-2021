using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : SingleSceneSingleton<NotificationManager>
{
    public Pager m_pagerUI;

    public void DisplayNotification(string notification)
    {
        m_pagerUI.DisplayNewText(notification);
    }
}
