using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool m_isInteractable;

    public void Start()
    {
        GetComponent<MiniGame>().m_onComplete += Clear;
    }

    public void Clear()
    {
        // This gets rid of the obstacle. We will just disable for now.
        gameObject.SetActive(false);
    }
}
