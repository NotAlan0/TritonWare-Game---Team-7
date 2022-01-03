using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ! Sometiems I specify UnityEngine in front of functions 
// ! As my unity is still in a very junky setup
public class HotspotSpawner : MonoBehaviour
{
    public GameObject bookshelf;
    public GameObject desknchair;
    public GameObject hotspotPrefab;
    static int uhOh;

    // I set up the range (0,4)
    // TODO: Refactor the code so that it would work with the weird shape Geisel has 
    // ! MIGHT SPAWN INSIDE PILLARS, FIX IT! 
    public float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        //Spawns a wifi hotspot as soon as the scene loads up 
        SpawnHotspot();
    }

    //Recursive method to check whether the hotspot spawner is created over another mesh
    bool SpawnHotspot()
    {
        // Represents a random vector position 
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-30, 30), 0, UnityEngine.Random.Range(-30, 30));
        //GameObject hotspot = Instantiate(hotspotPrefab, spawnPosition, Quaternion.identity) as GameObject;     
        RaycastHit hit;

        if(uhOh > 500)
        {
            UnityEngine.Debug.Log("the uhOh number has broken");
            //GameObject hotspot = Instantiate(hotspotPrefab, spawnPosition, Quaternion.identity) as GameObject; 
            //this is only because everything breaks without it
            return false;
        }
        if (Physics.Raycast( new Ray(spawnPosition, new Vector3(0, 0, -1)), out hit)) {
            uhOh++;
            UnityEngine.Debug.Log("Shooting a cast");
            if (hit.transform.gameObject.CompareTag("Block") || hit.transform == null) { 
                //this wont work right now, because the bookshelf/desknchair have meshes, not rigidbodies
                uhOh++;
                return SpawnHotspot();
            }
            else {
                GameObject hotspot = Instantiate(hotspotPrefab, spawnPosition, Quaternion.identity) as GameObject;
                return true;
            }
        } else { //if the raycast hits nothing, it's above open air
            UnityEngine.Debug.Log("Over Nothing");
            uhOh++;
            return SpawnHotspot();
        } 
    }
}
