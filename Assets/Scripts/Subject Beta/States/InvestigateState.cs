using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class InvestigateState : State
{
    [SerializeField] private float investigateSpeed;

    private bool IsAtDestination(NavMeshAgent navMeshAgent)
    {
        return navMeshAgent.transform.position == navMeshAgent.destination;
    }

    public override void Action(StateMachine stateMachine)
    {
        if (IsAtDestination(stateMachine.NavMeshAgent))
        {
            stateMachine.SwitchState(stateMachine.AllStates[(int)SubjectBetaStates.SniffState]);
        }
    }

    public override void EnterState(StateMachine stateMachine)
    {
        stateMachine.NavMeshAgent.speed = investigateSpeed;
    }
}
