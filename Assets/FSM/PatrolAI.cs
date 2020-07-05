using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] NavMeshAgent navMeshAgent;

    GameObject player;
    Animator animator;
    Ray ray;
    RaycastHit hit;
    float maxDistanceCheck;
    //Renamed: currentDistance -> distanceToTarget
    float distanceToTarget;
    Vector3 checkDirection;
    int currentTargetIndex;
    //Renamed: distanceFromTarget -> distanceToWaypoint
    float distanceToWaypoint;
    Transform[] waypoints;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        pointA = GameObject.Find("p1").transform;
        pointB = GameObject.Find("p2").transform;
        waypoints = new Transform[] { pointA, pointB };

        currentTargetIndex = 0;
        navMeshAgent.SetDestination(waypoints[currentTargetIndex].position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceToTarget = Vector3.Distance(player.transform.position, transform.position);
        animator.SetFloat("DistanceToTarget", distanceToTarget);
        checkDirection = (player.transform.position - transform.position).normalized;
        ray = new Ray(transform.position, checkDirection);

        if(Physics.Raycast(ray, out hit, maxDistanceCheck))
        {
            animator.SetBool("TargetVisible", hit.collider.gameObject == player);
        }

        distanceToWaypoint = Vector3.Distance(waypoints[currentTargetIndex].position, transform.position);
        animator.SetFloat("DistanceToWaypoint", distanceToWaypoint);
    }

    public void SetNextPoint()
    {
        switch (currentTargetIndex)
        {
            case 0: currentTargetIndex = 1;
                break;
            case 1: currentTargetIndex = 0;
                break;
        }
        navMeshAgent.SetDestination(waypoints[currentTargetIndex].position);
    }
}
