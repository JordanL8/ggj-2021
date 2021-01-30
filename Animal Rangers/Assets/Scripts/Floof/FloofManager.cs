using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloofManager : SingleSceneSingleton<FloofManager>
{
    public Floof[] m_floofPrefabs;

    public Floof GetRandomFloof()
    {
        return m_floofPrefabs[Random.Range(0, m_floofPrefabs.Length - 1)];
    }
}
