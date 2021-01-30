using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pager : MonoBehaviour
{
    public Vector3 m_initialPosition;
    public Vector3 m_displayPosition;

    public TextMeshProUGUI m_displayText;

    public float m_readingTime = 10.0f;

    private RectTransform m_rectTransform;

    public Button m_greenButton;

    private PlayerMovement m_playerController;


    private void Awake()
    {
        m_greenButton.interactable = false;
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        m_playerController = FindObjectOfType<PlayerMovement>();
    }

    public void DisplayNewText(string text, bool requireButton)
    {
        m_rectTransform.anchoredPosition = m_initialPosition;
        gameObject.SetActive(true);
        LeanTween.move(m_rectTransform, m_displayPosition, 1f)
            .setEase(LeanTweenType.easeOutCubic)
            .setOnComplete(() =>
            {
                m_displayText.text = text;
                if (!requireButton)
                {
                    HidePager(m_readingTime);
                }
                else
                {
                    m_greenButton.interactable = true;
                    m_playerController.Deactivate();
                }
            });
            
    }

    private void HidePager(float delay)
    {
        if (m_greenButton.interactable)
        {
            m_greenButton.interactable = false;
            m_playerController.Activate();
        }
        LeanTween.move(m_rectTransform, m_initialPosition, 1f)
            .setDelay(delay)
            .setEase(LeanTweenType.easeOutCubic)
            .setOnComplete(() =>
            {
                m_displayText.text = "";
                gameObject.SetActive(false);
            });
    }

    public void Close()
    {
        HidePager(0.0f);
    }

}
