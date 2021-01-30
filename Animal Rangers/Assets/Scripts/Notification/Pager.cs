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

    public void DisplayNewText(string text)
    {
        transform.position = m_initialPosition;
        gameObject.SetActive(true);
        LeanTween.move(gameObject, m_displayPosition, 2f)
            .setEase(LeanTweenType.easeInElastic)
            .setOnComplete(() =>
            {
                m_displayText.text = text;
                LeanTween.move(gameObject, m_initialPosition, 2f)
                .setDelay(m_readingTime)
                .setOnComplete(() =>
                {
                    gameObject.SetActive(false);
                    m_displayText.text = "";
                });
            });
            
    }

}
