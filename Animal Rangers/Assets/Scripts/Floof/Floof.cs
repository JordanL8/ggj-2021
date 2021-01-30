using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floof : MonoBehaviour
{
    public string m_floofType;

    private Region m_myRegion;
    public Region MyRegion => m_myRegion;

    public void SetRegion(Region region)
    {
        m_myRegion = region;
    }

    public void StartFollowing()
    {

    }
}
