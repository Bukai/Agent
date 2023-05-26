using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller_Agent : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    private int agentSpeed, radius;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.speed = agentSpeed;
            agent.SetDestination(randomMovePosition());
        }
    }

    private void Update()
    {
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(randomMovePosition());
        }
    }

    private Vector3 randomMovePosition()
    {
        Vector3 endPos = Vector3.zero;
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;

        if (NavMesh.SamplePosition(randomPos, out NavMeshHit hit, radius, 1))
        {
            endPos = hit.position;
        }
        return endPos;
    }
}
