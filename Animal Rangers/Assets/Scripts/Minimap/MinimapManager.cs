using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : SingleSceneSingleton<MinimapManager>
{
    public Transform m_miniMapCamera;

    public void Update()
    {
        Vector3 position = PlayerSwitch.playerInVehicle ? ThirdPersonMovement.Instance.transform.position : PlayerMovement.Instance.transform.position;
        position.y = m_miniMapCamera.transform.position.y;

        m_miniMapCamera.transform.position = position;
    }
}
