using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : SingleSceneSingleton<MinimapManager>
{
    private Transform m_target;

    public void SetTarget(Transform newTarget)
    {
        m_target = newTarget;
    }

    public void Update()
    {
        Vector3 newPosition = new Vector3(m_target.position.x, transform.position.y, m_target.position.z);
        transform.position = newPosition;
    }
}
