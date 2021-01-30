using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floof : MonoBehaviour
{
    public string m_floofType;

    private Region m_myRegion;
    public Region MyRegion => m_myRegion;

    private FloofMovement m_floofMovement;


    private void Start()
    {
        m_floofMovement = GetComponent<FloofMovement>();
    }
    public void SetRegion(Region region)
    {
        m_myRegion = region;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.GetComponent<PlayerMovement>())
        {
            m_floofMovement.target = other.gameObject.transform.root;
        }
    }
}
