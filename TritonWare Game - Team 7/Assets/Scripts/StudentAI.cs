using System.Diagnostics;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudentAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Animator Anim;
    public UnityEngine.Vector3 target;
    public Rigidbody rb;

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
        if ((transform.position - target).magnitude <= 0.1f)
        {
            Wander();
        }

        //Animations
        Anim.SetFloat("Horizontal", navMeshAgent.velocity.x); // this velocity part is a bit wacky, idk what else to use tho
        Anim.SetFloat("Vertical", navMeshAgent.velocity.y); // it works, but sometimes it acts wack as hell so yea
        Anim.SetFloat("Speed", Mathf.Abs(navMeshAgent.velocity.x + navMeshAgent.velocity.y)); // this is terrible

        //Set target, Go to Target, buy Target popcorn
        navMeshAgent.SetDestination(target);
    }

    void Wander()
    {
        UnityEngine.Vector3 nextTarget = new UnityEngine.Vector3(UnityEngine.Random.Range(-30, 30), transform.position.y, UnityEngine.Random.Range(-30, 30));
        target = nextTarget;
    }


}
