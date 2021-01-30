using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayManager : SingleSceneSingleton<DayManager>
{
    public delegate void VoidDayDelegate();
    public VoidDayDelegate m_processDayStart;
    public VoidDayDelegate m_processDayEnd;


    public float m_dayLength = 5.0f * 60.0f;
    private float m_curTime = 0.0f;
    private bool m_isTicking = false;

    private int m_currentDay = 0;
    public int CurrentDay => m_currentDay;

    public CanvasGroup m_newDayCanvas;
    public TextMeshProUGUI m_dayNumber;

    protected override void Awake()
    {
        m_newDayCanvas.alpha = 1.0f;
    }

    public void ProcessDayStart()
    {
        PlayerMovement.Instance.Deactivate();
        m_currentDay++;
        m_dayNumber.text = $"Day {CurrentDay.ToString()}";
        LeanTween.alphaCanvas(m_newDayCanvas, 1f, 1f).setEase(LeanTweenType.linear)
            .setOnComplete(() =>
            {
                LeanTween.alphaCanvas(m_newDayCanvas, 0f, 1f).setEase(LeanTweenType.linear)
                    .setDelay(3.0f)
                    .setOnComplete(() =>
                    {
                        PlayerMovement.Instance.Activate();

                        m_isTicking = true;
                        m_curTime = 0.0f;
        
                        m_processDayStart?.Invoke();
                    });
            });
    }

    public void ProcessDayEnd()
    {
        m_processDayEnd?.Invoke();
    }

    public void Update()
    {
        if(m_isTicking)
        {
            m_curTime += Time.deltaTime;
            if(m_curTime > m_dayLength)
            {
                m_isTicking = false;
                ProcessDayEnd();
            }
        }
    }
}
