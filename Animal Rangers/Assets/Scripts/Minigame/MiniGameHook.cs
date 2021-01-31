using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameHook : MonoBehaviour
{
    public MiniGame miniGameRef;
    public delegate void OnCompleteDelegate();
    public OnCompleteDelegate m_onComplete;


    public Transform miniGameTransform;
    private GameObject player;
    void Start()
    {
        // Find all appropriate objects in the game scene
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        float distance = Vector3.Distance(player.transform.position, miniGameTransform.position);
        if (distance < 10f)
        {
            SetUpMiniGame();
        }
       
    }

    public void SetUpMiniGame()
    {
        Debug.Log("setup");

        miniGameRef.gameObject.SetActive(true);
        miniGameRef.StartMiniGame(this);
    }

    public void Complete()
    {
        m_onComplete?.Invoke();
    }
}
