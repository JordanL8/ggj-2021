using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameHook : MonoBehaviour
{
    public MiniGame miniGameRef;
    public delegate void OnCompleteDelegate();
    public OnCompleteDelegate m_onComplete;
    public Camera miniGameCamera;

    public Transform miniGameTransform;
    private bool started = false;
    public void Update()
    {
        Vector3 pos = PlayerSwitch.playerInVehicle ? ThirdPersonMovement.Instance.transform.position : PlayerMovement.Instance.transform.position;
        float distance = Vector3.Distance(pos, miniGameTransform.position);
      //  Debug.Log(pos);
       // Debug.Log(distance);
        if (distance < 5f && !started)
        {
            started = true;
            SetUpMiniGame();
        }
       
    }

    public void SetUpMiniGame()
    {
        Debug.Log("setup");
        miniGameCamera.gameObject.SetActive(true);
        if (PlayerSwitch.playerInVehicle)
        {
            ThirdPersonMovement.Instance.Deactivate();
        }
        else
        {
            PlayerMovement.Instance.Deactivate();

        }
        miniGameRef.gameObject.SetActive(true);
        miniGameRef.StartMiniGame(this);
    }

    public void Complete()
    {
        miniGameCamera.gameObject.SetActive(false);
        if (PlayerSwitch.playerInVehicle)
        {
            ThirdPersonMovement.Instance.Activate();
        }
        else
        {
            PlayerMovement.Instance.Activate();

        }
        m_onComplete?.Invoke();
    }
}
