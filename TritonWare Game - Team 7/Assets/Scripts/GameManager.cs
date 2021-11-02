using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Imports TimerManager to deal with time
    public Timer TimerManager;

    public GameObject Countdown;
    public GameObject NoiseOutline;
    public GameObject WifiOutline;
    public GameObject WifiFilled;

    public GameObject StartButton;


    //
    private bool m_IsGameActive = false; 


    // Start is called before the first frame update
    void Start()
    {
        // Pulls all important game objects
        Countdown = GameObject.Find("Countdown");
        TimerManager = GameObject.Find("Countdown").GetComponent<Timer>();

        StartButton = GameObject.Find("StartButton");

        WifiOutline = GameObject.Find("WifiOutline");

        WifiFilled = GameObject.Find("WifiFilled");

        NoiseOutline = GameObject.Find("NoiseOutline");




        // Dissables all of the UI 
        NoiseOutline.SetActive(false);
        Countdown.SetActive(false);
        WifiOutline.SetActive(false);
        WifiFilled.SetActive(false);

        // Shows Start button Ui
        StartButton.SetActive(true);

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

        // Makes start button disappear and all of the other UI to appear
        StartButton.SetActive(false);

        NoiseOutline.SetActive(true);
        Countdown.SetActive(true);
        WifiOutline.SetActive(true);
        WifiFilled.SetActive(true);

    }

    void Update() 
    {
        GameFail();
    }

    void GameFail()
    {
        if(TimerManager.timeRemaining <= 0)
        {
            UnityEngine.Debug.Log("Game Over!");
            RestartGame();
            

        }
    }

    void RestartGame()
    {
        // Relods the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
