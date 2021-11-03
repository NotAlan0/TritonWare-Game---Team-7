using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Imports TimerManager to deal with time
    public Timer TimerManager;
    public LibrarianAI LibrarianAI;

    public GameObject Countdown;
    public GameObject NoiseOutline;
    public GameObject WifiOutline;
    public GameObject WifiFilled;

    public GameObject StartButton;
    public GameObject RestartButton;


    //
    private bool m_IsGameActive = false; 


    // Start is called before the first frame update
    void Start()
    {
        // Pulls all important game objects
        Countdown = GameObject.Find("Countdown");
        TimerManager = GameObject.Find("Countdown").GetComponent<Timer>();
        LibrarianAI = GameObject.Find("Librarian(Clone)").GetComponent<LibrarianAI>();

        StartButton = GameObject.Find("StartButton");
        RestartButton = GameObject.Find("RestartButton"); 

        WifiOutline = GameObject.Find("WifiOutline");

        WifiFilled = GameObject.Find("WifiFilled");

        NoiseOutline = GameObject.Find("NoiseOutline");




        // Dissables all of the UI 
        // ? This probably can be optimized
        NoiseOutline.SetActive(false);
        Countdown.SetActive(false);
        WifiOutline.SetActive(false);
        WifiFilled.SetActive(false);
        RestartButton.SetActive(false);

        // Shows Start button Ui
        StartButton.SetActive(true);

    }

    void Update() 
    {
        // Its better to call a method once the req is met
        // Rather then call a method every frame
        if ((TimerManager.timeRemaining <= 0) || (LibrarianAI.isCaught))
        {
            GameFail();
        }
    }

    // Calls the game fail screen
    void GameFail()
    {
        UnityEngine.Debug.Log("Game Over!");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Stops the timer
        TimerManager.timerIsRunning = false;

        // Shows restart button
        RestartButton.SetActive(true);

        // Deactivate all of the unused UI
        NoiseOutline.SetActive(false);
        Countdown.SetActive(false);
        WifiOutline.SetActive(false);
        WifiFilled.SetActive(false);

        
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

    // Restarts the game
    public void RestartGame()
    {
        // Relods the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
