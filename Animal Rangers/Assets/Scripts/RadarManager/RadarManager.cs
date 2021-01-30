using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class RadarManager : MonoBehaviour
{
    private GameObject player;
    private GameObject floof;

    // Start is called before the first frame update
    void Start()
    {
        // Find all appropriate objects in the game scene
        player = GameObject.FindGameObjectWithTag("Player");
        //floof = RescueManager.Instance.CurrentFloof

    }

    // Update is called once per frame
    void Update()
    {
        // check distance between objects 
        //((Vector3.Distance(characterController.target.transform.position, transform.position) < 2.0f))
    }
}
