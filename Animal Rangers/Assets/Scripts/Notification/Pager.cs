using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pager : MonoBehaviour
{
    public Vector3 m_initialPosition;
    public Vector3 m_displayPosition;

    public TextMeshProUGUI m_displayText;

    public float m_readingTime = 10.0f;

    private RectTransform m_rectTransform;


    private void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void DisplayNewText(string text)
    {
        m_rectTransform.anchoredPosition = m_initialPosition;
        gameObject.SetActive(true);
        LeanTween.move(m_rectTransform, m_displayPosition, 1f)
            .setEase(LeanTweenType.easeOutCubic)
            .setOnComplete(() =>
            {
                m_displayText.text = text;
                LeanTween.move(m_rectTransform, m_initialPosition, 1f)
                .setDelay(m_readingTime)
                .setEase(LeanTweenType.easeOutCubic)
                .setOnComplete(() =>
                {
                    m_displayText.text = "";
                    gameObject.SetActive(false);
                });
            });
            
    }

}
