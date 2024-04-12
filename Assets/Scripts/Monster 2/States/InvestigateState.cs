using System;
using UnityEngine;

[Serializable]
public class InvestigateState : State
{
    [SerializeField] private float investigateSpeed;
    [SerializeField] private Cluster[] clusters;
    [Range(2f, 5f)]
    [SerializeField] private float destinationAccuracy;
    private int currentCluster;
    private int currentDestination;

    public override void Action(StateMachine stateMachine)
    {
        float distance = GetDistance(clusters[currentCluster].Destinations[currentDestination], stateMachine);

        if (distance <= destinationAccuracy)
        {
            ++currentDestination;
            if (currentDestination >= clusters[currentCluster].Destinations.Length)
            {
                currentDestination = 0;
                stateMachine.SwitchState(stateMachine.AllStates[(int)Monster2States.RoamState]);
                return;
            }

            stateMachine.NavMeshAgent.destination = clusters[currentCluster].Destinations[currentDestination].position;
        }
    }

    public override void EnterState(StateMachine stateMachine)
    {
        stateMachine.NavMeshAgent.speed = investigateSpeed;
        currentCluster = GetClosestClusterIndex(stateMachine);
        stateMachine.NavMeshAgent.destination = clusters[currentCluster].Destinations[0].position;
    }

    private int GetClosestClusterIndex(StateMachine stateMachine)
    {
        float minDistance = GetDistance(clusters[0].Destinations[0], stateMachine);
        int minCluster = 0;
        for (int i = 0; i < clusters.Length; ++i)
        {
            for (int j = 0; j < clusters[i].Destinations.Length; ++j)
            {
                float distance = GetDistance(clusters[i].Destinations[j], stateMachine);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    minCluster = i;
                }
            }
        }

        return minCluster;
    }

    private float GetDistance(Transform destination, StateMachine stateMachine)
    {
        return (destination.position - stateMachine.NavMeshAgent.transform.position).magnitude;
    }
}

[Serializable]
internal class Cluster
{
    [SerializeField] public Transform[] Destinations;
}
