using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LibrarianAI : MonoBehaviour
{
    public Transform playerPos;
    NavMeshAgent navMeshAgent;
    public Player player;

    public Vector3 target;
    [SerializeField]
    private Vector3 currentPosition;

    public GameObject alert;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        target = new Vector3(0f,1.083333f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;

        if (player.noiseLevel >= .75f)
        {
            target = new Vector3(playerPos.position.x, 1.083333f, playerPos.position.z);
            Debug.Log("WOAH");

            alert.SetActive(true);
        }
        else
        {
            if (currentPosition == target)
            {
                Wander();
            }
            
            alert.SetActive(false);
        }

        navMeshAgent.SetDestination(target);
    }

    void Wander()
    {
        Vector3 nextTarget = new Vector3(UnityEngine.Random.Range(-20, 20), 1.083333f, UnityEngine.Random.Range(-20, 20));
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
}
