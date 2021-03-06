using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public static bool playerInVehicle = false;

    [SerializeField] PlayerMovement firstPersonController;
    [SerializeField] ThirdPersonMovement thirdPersonController;


    private void Update()
    {
        float distance = Vector3.Distance(PlayerMovement.Instance.controller.transform.position, ThirdPersonMovement.Instance.controller.transform.position);

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (distance < 10f && !playerInVehicle) //enter vehicle
            {
                thirdPersonController.Activate();
                firstPersonController.Deactivate();
                playerInVehicle = true;
                if (RescueManager.Instance.CurrentFloof.GetComponent<FloofMovement>().target != null)
                {
                    RescueManager.Instance.CurrentFloof.GetComponent<FloofMovement>().target = thirdPersonController.controller.transform;
                }
                RadarManager.Instance.m_target = thirdPersonController.controller.transform;
            }

            else if (playerInVehicle) //exit vehicle
            {
                firstPersonController.Activate();
                thirdPersonController.Deactivate();
                playerInVehicle = false;
                if (RescueManager.Instance.CurrentFloof.GetComponent<FloofMovement>().target != null)
                {
                    RescueManager.Instance.CurrentFloof.GetComponent<FloofMovement>().target = firstPersonController.controller.transform;
                }
                RadarManager.Instance.m_target = firstPersonController.controller.transform;
            }
        }
    }


 
}
