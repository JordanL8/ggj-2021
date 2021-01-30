using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.GetComponent<Floof>())
        {
            RescueManager.Instance.RescueFloofComplete();
        }
    }
}
