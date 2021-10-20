using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudentAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    public Vector3 target;

    [SerializeField]
    private Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = 2;
        target = new Vector3(transform.position.x + 1, 1.083333f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    { 
        currentPosition = transform.position;

        if (currentPosition == target)
        {
            Wander();
        }

        navMeshAgent.SetDestination(target);
    }

    void Wander()
    {
        Vector3 nextTarget = new Vector3(UnityEngine.Random.Range(-30, 30),transform.position.y, UnityEngine.Random.Range(-30, 30));
        target = nextTarget;
    }
}
