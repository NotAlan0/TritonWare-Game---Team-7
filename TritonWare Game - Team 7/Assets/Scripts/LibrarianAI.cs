using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LibrarianAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Player player;

    public Animator LibAnimator;

    public Vector3 target;
    [SerializeField]
    private Vector3 currentPosition;

    public GameObject alert;
    public float librarianSpeed;

    // Bool for if the player is isCaught
    public bool isCaught = false;

    //public Text text;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = librarianSpeed;
        target = new Vector3(0f,transform.position.y ,0f);

        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    { 

        if (player.noiseLevel >= .75f)
        {
            AlertOn();
        }
        else
        {
            AlertOff();
        }

        //Animation stuff
        navMeshAgent.SetDestination(target);

        LibAnimator.SetFloat("Horizontal", navMeshAgent.velocity.x); // this velocity part is a bit wacky, idk what else to use tho
        LibAnimator.SetFloat("Vertical", navMeshAgent.velocity.y); // it works, but sometimes it acts wack as hell so yea
        LibAnimator.SetFloat("Speed", Mathf.Abs(navMeshAgent.velocity.x + navMeshAgent.velocity.y)); // this is terrible
    }

    void Wander()
    {
        Vector3 nextTarget = new Vector3(UnityEngine.Random.Range(-20, 20),transform.position.y, UnityEngine.Random.Range(-20, 20));
        target = nextTarget;
    }

    void OnTriggerEnter(Collider collision)
    {
         if (collision.gameObject.tag == "Player" && player.noiseLevel >= .75f)
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("You 2 loud, get outta here");

            // Shows that player is Caught
            isCaught = true; 
        }
    }

    // Librarian switches to alerted mod 
    void AlertOn()
    {
        target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        //Debug.Log("WOAH"); This works and is messing up my testing, bad >:(

        // Librarian speeds up
        navMeshAgent.speed = 12f;

        alert.SetActive(true);
    }

    // Librarian calmns down
    void AlertOff()
    {
        if ((transform.position - target).magnitude <= 0.05f)
        {
            Wander();
        }

        alert.SetActive(false);
        navMeshAgent.speed = librarianSpeed;
    }
}
