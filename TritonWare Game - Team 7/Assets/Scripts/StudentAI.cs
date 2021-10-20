using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudentAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    public UnityEngine.Vector3 target;

    [SerializeField]
    private UnityEngine.Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = 2;

        Wander();

    }

    // Update is called once per frame
    void Update()
    { 
        // Doesn't depend on actuall position but rather the distance between two points
        if ((transform.position - target).magnitude <= 0.05f)
        {
            Wander();
        }

        navMeshAgent.SetDestination(target);

    }

    void Wander()
    {
        UnityEngine.Vector3 nextTarget = new UnityEngine.Vector3(UnityEngine.Random.Range(-30, 30), transform.position.y, UnityEngine.Random.Range(-30, 30));
        target = nextTarget;
    }
}
