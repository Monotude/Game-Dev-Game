using System;
using UnityEngine;
using UnityEngine.Animations;

[Serializable]
public class FleeState : MonsterState
{
    private float currentFleeDuration;
    private Vector3 fleeDestination;
    [SerializeField] private float fleeSpeed;
    [SerializeField] private float fleeDuration;

    private Vector3 GetFleeDestination(Transform monster, Vector3 direction)
    {
        Ray ray = new Ray(monster.position, direction);
        Physics.Raycast(ray, out RaycastHit hit);
        return hit.point;
    }

    private void SetFleeDestination(MonsterStateMachine monsterStateMachine)
    {
        monsterStateMachine.NavMeshAgent.destination = GetFleeDestination(monsterStateMachine.transform, -monsterStateMachine.transform.forward);
        fleeDestination = monsterStateMachine.NavMeshAgent.destination;
    }

    private bool AtDestination(MonsterStateMachine monsterStateMachine)
    {
        Vector3 monsterPosition = monsterStateMachine.gameObject.transform.position;
        return fleeDestination.x == monsterPosition.x && fleeDestination.z == monsterPosition.z;
    }

    public override void EnterState(MonsterStateMachine monsterStateMachine)
    {
        currentFleeDuration = 0f;
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

        else if (AtDestination(monsterStateMachine))
        {
            SetFleeDestination(monsterStateMachine);
        }
    }
}
