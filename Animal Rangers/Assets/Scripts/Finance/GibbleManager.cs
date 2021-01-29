using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibbleManager : SingleSceneSingleton<GibbleManager>
{
    private float m_gibbles = 0.0f;
    public float Gibbles => m_gibbles;

    public bool Debit(float amount)
    {
        if (m_gibbles - amount < 0.0f)
        {
            return false;
        }

        m_gibbles -= amount;
        return true;
    }

    public void Credit(float amount)
    {
        m_gibbles += amount;
    }
}
