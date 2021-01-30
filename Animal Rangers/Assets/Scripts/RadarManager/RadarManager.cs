using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RadarManager : MonoBehaviour
{
    private GameObject player;
    private GameObject floof;

    [SerializeField] private GameObject lakesideEntrance;

    private enum RadarState { BOILING, HOT, COLD, FREEZING, DISABLED};
    public enum BiomeState { SPAWN, FOREST, LAKESIDE, MUSHROOM, FLOWERPLAINS};
    private RadarState radarState = RadarState.FREEZING;
    public static BiomeState biomeState = BiomeState.SPAWN;

    [SerializeField] Image boilingRadar; // Right on top of floof
    [SerializeField] Image hotRadar; // Correct region, halfway there
    [SerializeField] Image coldRadar; // Correct region, wrong side of region
    [SerializeField] Image freezingRadar; // Wrong region
    [SerializeField] GameObject pager;

    // Start is called before the first frame update
    void Start()
    {
        // Find all appropriate objects in the game scene
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        floof = RescueManager.Instance.CurrentFloof.gameObject;
        if (pager.activeSelf)
        {
            radarState = RadarState.DISABLED;
        }
        else if (biomeState != RescueManager.Instance.CurrentFloof.MyRegion.floofBiome)
        {
            radarState = RadarState.FREEZING;
        }
        else
        {
            Debug.Log(biomeState);
            // check distance between objects 
            float distance = Vector3.Distance(player.transform.position, floof.transform.position);
            if (distance > 50f)
            {
                radarState = RadarState.COLD;
            }
            if (distance > 5f && distance < 50f)
            {
                radarState = RadarState.HOT;
            }
            if (distance < 5f)
            {
                radarState = RadarState.BOILING;
            }


        }
        switch (radarState)
        {
            case RadarState.BOILING:
                boilingRadar.enabled = true;
                hotRadar.enabled = false;
                coldRadar.enabled = false;
                freezingRadar.enabled = false;
                break;
            case RadarState.HOT:
                boilingRadar.enabled = false;
                hotRadar.enabled = true;
                coldRadar.enabled = false;
                freezingRadar.enabled = false;
                break;
            case RadarState.COLD:
                boilingRadar.enabled = false;
                hotRadar.enabled = false;
                coldRadar.enabled = true;
                freezingRadar.enabled = false;
                break;
            case RadarState.FREEZING:
                boilingRadar.enabled = false;
                hotRadar.enabled = false;
                coldRadar.enabled = false;
                freezingRadar.enabled = true;
                break;
            case RadarState.DISABLED:
                boilingRadar.enabled = false;
                hotRadar.enabled = false;
                coldRadar.enabled = false;
                freezingRadar.enabled = false;
                break;
        }
    }
}
