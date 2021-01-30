using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : SingleSceneSingleton<NotificationManager>
{
    public Pager m_pagerUI = null;

    public void DisplayNotification(string notification)
    {
        m_pagerUI.DisplayNewText(notification);
    }

    private void Start()
    {
        if(m_pagerUI == null)
        {
            m_pagerUI = FindObjectOfType<Pager>();
        }
    }
}
