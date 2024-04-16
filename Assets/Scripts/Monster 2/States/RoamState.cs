using System;
using UnityEngine;

[Serializable]
public class RoamState : State
{
    [SerializeField] private float roamSpeed;
    [SerializeField] private Transform[] destinations;
    [Range(2f, 5f)]
    [SerializeField] private float destinationAccuracy;
    private Vector3 currentDestination;

    private Vector3 GetDestination()
    {
        Vector3 destination = destinations[UnityEngine.Random.Range(0, destinations.Length)].position;

        while (destination == currentDestination)
        {
            destination = destinations[UnityEngine.Random.Range(0, destinations.Length)].position;
        }

        return destination;
    }

    public override void EnterState(StateMachine stateMachine)
    {
        stateMachine.NavMeshAgent.speed = roamSpeed;
        currentDestination = GetDestination();
        stateMachine.NavMeshAgent.destination = currentDestination;
    }

    public override void Action(StateMachine stateMachine)
    {
        Vector3 distanceVector = stateMachine.NavMeshAgent.transform.position - currentDestination;

        if (distanceVector.magnitude <= destinationAccuracy)
        {
            currentDestination = GetDestination();
            stateMachine.NavMeshAgent.destination = currentDestination;
        }
    }
}
