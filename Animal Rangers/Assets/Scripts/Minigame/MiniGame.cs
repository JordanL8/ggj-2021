using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    private Obstacle m_parent;

    public void Initialise(Obstacle parent)
    {
        m_parent = parent;
    }

    protected virtual void Complete()
    {
        m_parent.Clear();
    }
}
