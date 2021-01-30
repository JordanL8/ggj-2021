using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : SingleSceneSingleton<NotificationManager>
{
    public Pager m_pagerUI = null;

    public string[] m_notificationTexts;

    public string m_floofTextColor;
    public string m_biomeTextColor;

    public void DisplayNotification(string floofType, string biomeType, Pager.OnPagerCloseDelegate onPagerClose = null)
    {
        string formattedFloofText = $"<color={m_floofTextColor}>" + floofType + "</color>";
        string formattedBiomeText = $"<color={m_biomeTextColor}>" + biomeType + "</color>";
        string notification = m_notificationTexts[Random.Range(0, m_notificationTexts.Length - 1)].Replace("(floof)", formattedFloofText).Replace("(biome)", formattedBiomeText);
        m_pagerUI.DisplayNewText(notification, false, onPagerClose);
    }

    public void DisplayNotification(string notification, bool requireButton = false, Pager.OnPagerCloseDelegate onPagerClose = null)
    {
        m_pagerUI.DisplayNewText(notification, requireButton, onPagerClose);
    }

    protected override void Awake()
    {
        base.Awake();
        if(m_pagerUI == null)
        {
            m_pagerUI = FindObjectOfType<Pager>();
        }

        m_pagerUI.gameObject.SetActive(false);
    }
}
