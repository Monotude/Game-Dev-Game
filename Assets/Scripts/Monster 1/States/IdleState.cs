using System;
using UnityEngine;

[Serializable]
public class IdleState : State
{
    private float currentIdleTime;
    [SerializeField] private float idleTime;
    [Range(0f, 360f)]
    [SerializeField] private float monsterFieldOfView;
    [SerializeField] private float monsterVisionRange;

    private bool IsPlayerSeen(StateMachine stateMachine)
    {
        Transform monster = stateMachine.NavMeshAgent.transform;
        Transform player = stateMachine.Player;

        Vector3 monsterToPlayer = (player.position - monster.position).normalized;
        float angle = Vector3.Dot(monster.forward, monsterToPlayer);
        bool lookingAtPlayerDirection = Mathf.Cos(Mathf.Deg2Rad * monsterFieldOfView / 2) <= angle;

        if (!lookingAtPlayerDirection)
        {
            return false;
        }

        Ray ray = new Ray(monster.position, monsterToPlayer);
        Physics.Raycast(ray, out RaycastHit hit, monsterVisionRange);

        return hit.transform == player;
    }

    public override void EnterState(StateMachine stateMachine)
    {
        currentIdleTime = 0f;
    }

    public override void Action(StateMachine stateMachine)
    {
        ChaseState chaseState = (ChaseState)stateMachine.AllStates[(int)Monster1States.ChaseState];

        if (chaseState.IsTimeToChase() || IsPlayerSeen(stateMachine))
        {
            stateMachine.SwitchState(chaseState);
        }

        currentIdleTime += Time.deltaTime;

        if (currentIdleTime >= idleTime)
        {
            stateMachine.SwitchState(stateMachine.AllStates[(int)Monster1States.PatrolState]);
        }
    }
}
