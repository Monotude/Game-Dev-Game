using System;
using UnityEngine;

[Serializable]
public class AggroState : State
{
    [SerializeField] private float aggroSpeed;

    public override void EnterState(StateMachine stateMachine)
    {
        stateMachine.NavMeshAgent.speed = aggroSpeed;
        stateMachine.NavMeshAgent.destination = stateMachine.Player.position;
    }

    public override void Action(StateMachine stateMachine)
    {
        stateMachine.NavMeshAgent.destination = stateMachine.Player.position;
    }
}
