using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloofSpawner : SingleSceneSingleton<FloofSpawner>
{
    public Floof SpawnFloofs(Floof floof, Transform[] spawnPoints)
    {
        int randomPoint = Random.Range(0, spawnPoints.Length);

        Vector3 spawnLocation = new Vector3(spawnPoints[randomPoint].position.x,
                                            spawnPoints[randomPoint].position.y,
                                            spawnPoints[randomPoint].position.z);

        return Instantiate(floof, spawnLocation, Quaternion.identity);
    }
}
