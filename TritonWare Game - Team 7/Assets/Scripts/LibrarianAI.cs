using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LibrarianAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Player player;

    public Vector3 target;
    [SerializeField]
    private Vector3 currentPosition;

    public GameObject alert;
    public float librarianSpeed;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = librarianSpeed;
        target = new Vector3(0f,transform.position.y ,0f);
    }

    // Update is called once per frame
    void Update()
    { 
        currentPosition = transform.position;

        if (player.noiseLevel >= .75f)
        {
            AlertOn();
        }
        else
        {
            AlertOff();
        }

        navMeshAgent.SetDestination(target);
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
        }
    }

    // Librarian switches to alerted mod 
    void AlertOn()
    {
        target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        //Debug.Log("WOAH"); This works and is messing up my testing, bad >:(

        // Librarian speeds up
        navMeshAgent.speed = 8.0f;

        alert.SetActive(true);
    }

    // Librarian calmns down
    void AlertOff()
    {
        if (currentPosition == target)
        {
            Wander();
        }

        alert.SetActive(false);
        navMeshAgent.speed = librarianSpeed;
    }
}
