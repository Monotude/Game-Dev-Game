using System;
using UnityEngine;

[Serializable]
public class IdleState : MonsterState
{
    private float currentIdleTime;
    [SerializeField] private float idleTime;
    [Range(0f, 360f)]
    [SerializeField] private float monsterFieldOfView;
    [SerializeField] private float monsterVisionRange;

    private bool IsPlayerSeen(MonsterStateMachine monsterStateMachine)
    {
        Transform monster = monsterStateMachine.gameObject.transform;
        Transform player = monsterStateMachine.Player;

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

    public override void EnterState(MonsterStateMachine monsterStateMachine)
    {
        currentIdleTime = 0f;
    }

    public override void Action(MonsterStateMachine monsterStateMachine)
    {
        if (monsterStateMachine.ChaseState.IsTimeToChase() || IsPlayerSeen(monsterStateMachine))
        {
            monsterStateMachine.SwitchState(monsterStateMachine.ChaseState);
        }

        currentIdleTime += Time.deltaTime;

        if (currentIdleTime >= idleTime)
        {
            monsterStateMachine.SwitchState(monsterStateMachine.PatrolState);
        }
    }
}
