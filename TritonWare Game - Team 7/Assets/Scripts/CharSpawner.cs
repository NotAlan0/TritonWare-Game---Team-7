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

    // Start is called before the first frame update
    void Start()
    {
        //Spawns librarian as soon as the scene loads up 
        SpawnLibrarian();

        //Spawns player as soon as the scene loads up 
        SpawnPlayer();
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