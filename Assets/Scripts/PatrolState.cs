using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class PatrolState : MonsterState
{
    private Vector3 patrolDestination;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private Transform[] destinations;
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

    private bool AtDestination(MonsterStateMachine monsterStateMachine)
    {
        Vector3 monsterPosition = monsterStateMachine.gameObject.transform.position;
        return patrolDestination.x == monsterPosition.x && patrolDestination.z == monsterPosition.z;
    }

    public bool IsPlayerSeen(MonsterStateMachine monsterStateMachine)
    {
        Transform monster = monsterStateMachine.gameObject.transform;
        Transform player = monsterStateMachine.Player;

        Vector3 monsterToPlayer = player.position - monster.position;
        float angle = Vector3.Dot(monster.forward, monsterToPlayer);
        bool lookingAtPlayerDirection = 0.6f < angle;

        if (!lookingAtPlayerDirection)
        {
            return false;
        }

        Ray ray = new Ray(monster.position, monsterToPlayer);
        Physics.Raycast(ray, out RaycastHit hit, monsterVisionRange);

        return hit.transform == player;
    }

    public bool IsChaseCooldownOver(MonsterStateMachine monsterStateMachine)
    {
        return chaseCooldownTime <= monsterStateMachine.ChaseState.TimeUntilChase - monsterStateMachine.ChaseState.CurrentTimeUntilChase;
    }

    public void EnterState(MonsterStateMachine monsterStateMachine)
    {
        patrolDestination = GetPatrolDestination();
        monsterStateMachine.NavMeshAgent.destination = patrolDestination;
        monsterStateMachine.NavMeshAgent.speed = patrolSpeed;
    }

    public void Action(MonsterStateMachine monsterStateMachine)
    {
        if ((monsterStateMachine.ChaseState.IsTimeToChase() || IsPlayerSeen(monsterStateMachine)) && IsChaseCooldownOver(monsterStateMachine))
        {
            monsterStateMachine.SwitchState(monsterStateMachine.ChaseState);
        }

        if (AtDestination(monsterStateMachine))
        {
            monsterStateMachine.SwitchState(monsterStateMachine.IdleState);
        }
    }
}


