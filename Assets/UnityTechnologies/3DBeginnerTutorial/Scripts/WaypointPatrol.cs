using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    [SerializeField] int currentWaypointIdx;
    [SerializeField] NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance) {
            currentWaypointIdx = (currentWaypointIdx + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIdx].position);
        }
    }
}
