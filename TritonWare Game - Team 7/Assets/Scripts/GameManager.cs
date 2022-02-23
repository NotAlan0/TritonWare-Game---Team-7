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

    public GameObject UI;

    public GameObject Background;
    public GameObject startMenu;
    public GameObject restartScreen;

    //
    private bool m_IsGameActive = false; 

    // Start is called before the first frame update
    void Start()
    {
        // Pulls all important game objects

        // We dont really need this, we can just set em in the game. Setting it so that it has to find each object is slow
        /*
        Countdown = GameObject.Find("Countdown");
        TimerManager = GameObject.Find("Countdown").GetComponent<Timer>();
        
        Background = GameObject.Find("Background");
        StartButton = GameObject.Find("StartButton");
        RestartButton = GameObject.Find("RestartButton"); 

        WifiOutline = GameObject.Find("WifiOutline");
        WifiFilled = GameObject.Find("WifiFilled");
        NoiseOutline = GameObject.Find("NoiseOutline");
        */
        
        LibrarianAI = GameObject.Find("Librarian(Clone)").GetComponent<LibrarianAI>();


        // Dissables all of the UI 
        // ? This probably can be optimized
        UI.SetActive(false);
        restartScreen.SetActive(false);

        // Shows Start button Ui
        startMenu.SetActive(true);
        Background.SetActive(true);
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


        // Deactivate all of the unused UI, then activate restart
        UI.SetActive(false);


        // Shows restart button
        restartScreen.SetActive(true);

        
        Background.SetActive(true);

        

        
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
        startMenu.SetActive(false);
        Background.SetActive(false);

        UI.SetActive(true);

    }

    // Restarts the game
    public void RestartGame()
    {
        // Relods the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
