using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LibrarianAI : MonoBehaviour
{
    public Transform destination;
    NavMeshAgent navMeshAgent;
    public Player player;
    public Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.noiseLevel >= .5f)
        {
            targetVector = destination.transform.position;
            Debug.Log("WOAH");
        }
        else
        {
            StartCoroutine(Wander());
        }

        navMeshAgent.SetDestination(targetVector);
    }

    IEnumerator Wander()
    {
        yield return new WaitForSeconds(10);
        Vector3 nextTarget = new Vector3(UnityEngine.Random.Range(-20, 20), 0, UnityEngine.Random.Range(-20, 20));
        targetVector = nextTarget;
    }
}
