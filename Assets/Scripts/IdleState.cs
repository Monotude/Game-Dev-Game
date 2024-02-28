using System;
using UnityEngine;

[Serializable]
public class IdleState : MonsterState
{
    private float currentIdleTime;
    [SerializeField] private float idleTime;
    [SerializeField] private float monsterVisionRange;

    public bool IsPlayerSeen(MonsterStateMachine monsterStateMachine)
    {
        Transform monster = monsterStateMachine.gameObject.transform;
        Transform player = monsterStateMachine.Player;

        Vector3 monsterToPlayer = player.position - monster.position;
        float angle = Vector3.Dot(monster.forward, monsterToPlayer);
        bool lookingAtPlayerDirection = 0.35f < angle;

        if (!lookingAtPlayerDirection)
        {
            return false;
        }

        Ray ray = new Ray(monster.position, monsterToPlayer);
        Physics.Raycast(ray, out RaycastHit hit, monsterVisionRange);

        return hit.transform == player;
    }

    public override void EnterState(MonsterStateMachine monsterStateMachine)
    {
        currentIdleTime = idleTime;
    }

    public override void Action(MonsterStateMachine monsterStateMachine)
    {
        if (monsterStateMachine.ChaseState.IsTimeToChase() || IsPlayerSeen(monsterStateMachine))
        {
            monsterStateMachine.SwitchState(monsterStateMachine.ChaseState);
        }

        currentIdleTime -= Time.deltaTime;

        if (currentIdleTime <= 0)
        {
            monsterStateMachine.SwitchState(monsterStateMachine.PatrolState);
        }
    }
}
