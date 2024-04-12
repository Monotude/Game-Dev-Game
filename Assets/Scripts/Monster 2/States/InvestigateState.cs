using System;
using UnityEngine;

[Serializable]
public class InvestigateState : State
{


    //relative to the waypoints
    [SerializeField] private Transform[][] destinations;
    private Transform closestDestination;
    [Range(2f, 5f)]
    [SerializeField] private float destinationAccuracy;
    [SerializeField] private float investigateSpeed;
    private Vector3 monsterPosition;
    private Vector3 destinationGoal;
    private float shortestDistance;
    private float distance;
    private int destinationNumber;
    private int clusterNumber;
    private int closestDestinationNumber;
    private int closestClusterNumber;
    private int destinationsToTraverse;
    private int currentDestinationTraversing = 0;

    public override void Action(StateMachine stateMachine)
    {
        //Use cluster value to roam through each destination in that cluste
        Vector3 distanceVector = stateMachine.NavMeshAgent.transform.position - destinations[clusterNumber][currentDestinationTraversing].position;
        
        //if close enough to destination
        if (distanceVector.magnitude <= destinationAccuracy)
        {
            currentDestinationTraversing++;
            if (currentDestinationTraversing > destinationsToTraverse)
                        {
                            //go roaming state
                            currentDestinationTraversing = 0;
                            stateMachine.SwitchState(stateMachine.AllStates[(int)Monster2States.RoamState]);
                        }

            stateMachine.NavMeshAgent.SetDestination(destinations[clusterNumber][currentDestinationTraversing].position);
         }
          

    }

    public override void EnterState(StateMachine stateMachine)
    {
        stateMachine.NavMeshAgent.speed = investigateSpeed;
        monsterPosition = stateMachine.NavMeshAgent.transform.position;

        //find nearestDestination
        calculateClosestDestinationIndex();
        stateMachine.NavMeshAgent.SetDestination(destinations[closestClusterNumber][currentDestinationTraversing].position);
    }

    void calculateClosestDestinationIndex()
    {
        
        for (clusterNumber = 0; clusterNumber < destinations.Length ; clusterNumber++)
        {
            for (int destinationTracker = 0; destinationTracker < destinations[clusterNumber].Length; destinationTracker++)
            {
                //grab position of current destination

                Vector3 destinationPosition = destinations[clusterNumber][destinationTracker].position;


                //calculate distance between 2 vectors
                distance = Vector3.Distance(destinationPosition, monsterPosition);

                //assign the shortestDistance
                if (distance < shortestDistance)
                {
                    destinationGoal = destinations[clusterNumber][destinationTracker].position;
                    shortestDistance = distance;
                    closestDestination = destinations[clusterNumber][destinationTracker];
                    closestDestinationNumber = destinationTracker;
                    closestClusterNumber = clusterNumber;
                }
            } 
        } 
    }
}
