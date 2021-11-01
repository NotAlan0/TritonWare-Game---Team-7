using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Imports TimerManager to deal with time
    public Timer TimerManager;

    public GameObject StartButton;


    //
    private bool m_IsGameActive = false; 


    // Start is called before the first frame update
    void Start()
    {
        TimerManager = GameObject.Find("Countdown").GetComponent<Timer>();
        StartButton = GameObject.Find("StartButton");

    }

    // Function that starts the game when StartButton is clicked
    public void StartGame()
    {
        m_IsGameActive = true;
        UnityEngine.Debug.Log("Starting the game");

        // Locks cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Starts the timmer 
        TimerManager.timerIsRunning = true;

        // Makes start button disappear
        StartButton.SetActive(false);
    }
}
