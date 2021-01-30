using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionEntrance : MonoBehaviour
{
    public RadarManager.BiomeState biomeToEnter;

    private void OnTriggerEnter(Collider other)
    {
        RadarManager.biomeState = biomeToEnter;
    }
}
