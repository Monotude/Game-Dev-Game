using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class PatrolState : State
{
    private Vector3 patrolDestination;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private Transform[] destinations;
    [Range(0f, 360f)]
    [SerializeField] private float monsterFieldOfView;
    [SerializeField] private float monsterVisionRange;
    [SerializeField] private float chaseCooldownTime;

    private Vector3 GetPatrolDestination()
    {
        Vector3 newPatrolDestination = destinations[Random.Range(0, destinations.Length)].position;

        while (newPatrolDestination == patrolDestination)
        {
            newPatrolDestination = destinations[Random.Range(0, destinations.Length)].position;
        }

        return newPatrolDestination;
    }

    private bool AtDestination(StateMachine stateMachine)
    {
        Vector3 monsterPosition = stateMachine.NavMeshAgent.transform.position;
        return patrolDestination.x == monsterPosition.x && patrolDestination.z == monsterPosition.z;
    }

    private bool IsPlayerSeen(StateMachine stateMachine)
    {
        Transform monster = stateMachine.NavMeshAgent.gameObject.transform;
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

    private bool IsChaseCooldownOver(StateMachine stateMachine)
    {
        ChaseState chaseState = (ChaseState)stateMachine.AllStates[(int)SubjectAlphaStates.ChaseState];
        return chaseCooldownTime <= chaseState.TimeUntilChase - chaseState.CurrentTimeUntilChase;
    }

    public override void EnterState(StateMachine stateMachine)
    {
        patrolDestination = GetPatrolDestination();
        stateMachine.NavMeshAgent.destination = patrolDestination;
        stateMachine.NavMeshAgent.speed = patrolSpeed;
    }

    public override void Action(StateMachine stateMachine)
    {
        ChaseState chaseState = (ChaseState)stateMachine.AllStates[(int)SubjectAlphaStates.ChaseState];

        if ((chaseState.IsTimeToChase() || IsPlayerSeen(stateMachine)) && IsChaseCooldownOver(stateMachine))
        {
            stateMachine.SwitchState(chaseState);
        }

        else if (AtDestination(stateMachine))
        {
            stateMachine.SwitchState(stateMachine.AllStates[(int)SubjectAlphaStates.IdleState]);
        }
    }
}


