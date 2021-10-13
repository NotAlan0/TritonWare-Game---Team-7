using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ! Sometiems I specify UnityEngine in front of functions 
// ! As my unity is still in a very junky setup
public class HotspotSpawner : MonoBehaviour
{

    public GameObject hotspotPrefab;

    // I set up the range (0,4)
    // TODO: Refactor the code so that it would work with the weird shape Geisel has 
    // ! MIGHT SPAWN INSIDE PILLARS, FIX IT! 
    public Vector2 spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        //Spawns a wifi hotspot as soon as the scene loads up 
        SpawnHotspot();
    }

    //
    void SpawnHotspot()
    {
        // Represents a random vector position 
        Vector3 spawnPosition = new Vector3(
            UnityEngine.Random.Range(spawnRange[0], spawnRange[1]),
            0,
            UnityEngine.Random.Range(spawnRange[0], spawnRange[1])
        );

        // Creats a new instance of WifiHotspot objects aka spawns our hotspot
        GameObject hotspot = Instantiate(hotspotPrefab, spawnPosition, Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
