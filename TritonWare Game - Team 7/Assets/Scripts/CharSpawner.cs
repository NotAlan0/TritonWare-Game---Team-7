using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ! Sometiems I specify UnityEngine in front of functions 
// ! As my unity is still in a very junky setup
public class CharSpawner : MonoBehaviour
{

    public GameObject librarianPrefab;
    public GameObject playerPrefab;

    // ! MIGHT SPAWN INSIDE OTHER OBJECTS
    public Vector2 librarianSpawnRange;
    public Vector2 playerSpawnRange;

    public int uhOh = 0;
    public int timesToRecurse;

    // Start is called before the first frame update
    void Start()
    {
        //Spawns librarian as soon as the scene loads up 
        spawnLibrarian2();

        //Spawns player as soon as the scene loads up 
        // ! Commented for now
        //SpawnPlayer();
    }

    // Method that spawns librarian
    void SpawnLibrarian()
    {
        // Represents a random vector position 
        Vector3 librarianSpawnPosition = new Vector3(
            UnityEngine.Random.Range(librarianSpawnRange[0], librarianSpawnRange[1]), 
            1, 
            UnityEngine.Random.Range(librarianSpawnRange[0], librarianSpawnRange[1])
        );
        // Creats a new instance of librarian object aka spawns our librarian
        GameObject librarian = Instantiate(librarianPrefab, librarianSpawnPosition, Quaternion.identity) as GameObject;
    }

    bool spawnLibrarian2()
    {
        // Represents a random vector position 
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-librarianSpawnRange[0], librarianSpawnRange[1]), 0, 
               UnityEngine.Random.Range(-librarianSpawnRange[0], librarianSpawnRange[1]));
        //GameObject hotspot = Instantiate(hotspotPrefab, spawnPosition, Quaternion.identity) as GameObject;     
        RaycastHit hit;

        if (uhOh > timesToRecurse)
        {
            UnityEngine.Debug.Log("the uhOh number has broken");
            //GameObject hotspot = Instantiate(hotspotPrefab, spawnPosition, Quaternion.identity) as GameObject; 
            //this is only because everything breaks without it
            return false;
        }
        if (Physics.Raycast(new Ray(spawnPosition, new Vector3(0, 0, -1)), out hit))
        {
            uhOh++;
            //UnityEngine.Debug.Log("Shooting a cast");
            if (hit.transform.gameObject.CompareTag("Block") || hit.transform == null)
            {
                //this wont work right now, because the bookshelf/desknchair have meshes, not rigidbodies
                uhOh++;
                return spawnLibrarian2();
            }
            else
            {
                GameObject librarian = Instantiate(librarianPrefab, spawnPosition, Quaternion.identity) as GameObject;
                return true;
            }
        }
        else
        { //if the raycast hits nothing, it's above open air
            UnityEngine.Debug.Log("Over Nothing");
            uhOh++;
            return spawnLibrarian2();
        }
    }

    // Method that spawns player
    void SpawnPlayer()
    {
        // Represents a random spawn position 
        Vector3 playerSpawnPosition = new Vector3(
            UnityEngine.Random.Range(playerSpawnRange[0], playerSpawnRange[1]),
            1,
            UnityEngine.Random.Range(playerSpawnRange[0], playerSpawnRange[1])
        );

        // Creats a new instance of  player  aka spawns our player
        GameObject player = Instantiate(playerPrefab, playerSpawnPosition, Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}