using System;
using UnityEngine;
using UnityEngine.Animations;

[Serializable]
public class FleeState : MonsterState
{
    private float currentFleeDuration;
    [SerializeField] private float fleeSpeed;
    [SerializeField] private float fleeDuration;

    private Vector3 GetFleeDestination(Transform monster)
    {
        Physics.Raycast(monster.position, -monster.forward, out RaycastHit hit);
        return hit.point;
    }

    private void SetFleeDestination(MonsterStateMachine monsterStateMachine)
    {
        monsterStateMachine.NavMeshAgent.destination = GetFleeDestination(monsterStateMachine.transform);
    }

    public override void EnterState(MonsterStateMachine monsterStateMachine)
    {
        currentFleeDuration = 0f;
        monsterStateMachine.NavMeshAgent.velocity = monsterStateMachine.NavMeshAgent.velocity * .5f;
        monsterStateMachine.NavMeshAgent.speed = fleeSpeed;
        monsterStateMachine.transform.GetComponent<LookAtConstraint>().constraintActive = true;
        SetFleeDestination(monsterStateMachine);
    }

    public override void Action(MonsterStateMachine monsterStateMachine)
    {
        currentFleeDuration += Time.deltaTime;

        if (currentFleeDuration >= fleeDuration)
        {
            monsterStateMachine.transform.GetComponent<LookAtConstraint>().constraintActive = false;
            monsterStateMachine.SwitchState(monsterStateMachine.PatrolState);
        }

        else
        {
            SetFleeDestination(monsterStateMachine);
        }
    }
}
