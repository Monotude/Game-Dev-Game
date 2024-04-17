using System;
using UnityEngine;
using UnityEngine.Animations;

[Serializable]
public class FleeState : State
{
    private float currentStunBuffer;
    [SerializeField] private Light uVLightLight;
    [SerializeField] private PlayerUVLight playerUVLight;
    [Range(1f, 0f)]
    [SerializeField] private float stoppingSpeed;
    [SerializeField] private float stunBufferSeconds;
    [SerializeField] private float fleeSpeed;

    private Vector3 GetFleeDestination(Transform monster)
    {
        Physics.Raycast(monster.position, -monster.forward, out RaycastHit hit);
        return hit.point;
    }

    private void SetFleeDestination(StateMachine monsterStateMachine)
    {
        monsterStateMachine.NavMeshAgent.destination = GetFleeDestination(monsterStateMachine.NavMeshAgent.transform);
    }

    private void IsRestunned(StateMachine monsterStateMachine)
    {
        if (IsStunned(monsterStateMachine))
        {
            currentStunBuffer = 0f;
        }
    }

    private bool IsStunned(StateMachine monsterStateMachine)
    {
        if (!playerUVLight.IsUVLightOn)
        {
            return false;
        }

        Transform camera = Camera.main.transform;
        Transform monster = monsterStateMachine.NavMeshAgent.transform;

        Vector3 cameraToMonster = monster.position - camera.position;
        float angle = Vector3.Dot(camera.forward, cameraToMonster);
        bool lookingAtMonsterDirection = Mathf.Cos(Mathf.Deg2Rad * uVLightLight.innerSpotAngle / 2) <= angle;

        if (!lookingAtMonsterDirection)
        {
            return false;
        }

        Transform player = monsterStateMachine.Player;

        Vector3 playerToMonster = monster.position - player.position;
        Ray ray = new Ray(player.position, playerToMonster);
        Physics.Raycast(ray, out RaycastHit hit, uVLightLight.range);

        return hit.transform == monster;
    }

    public override void EnterState(StateMachine monsterStateMachine)
    {
        currentStunBuffer = 0f;
        monsterStateMachine.NavMeshAgent.velocity = monsterStateMachine.NavMeshAgent.velocity * stoppingSpeed;
        monsterStateMachine.NavMeshAgent.speed = fleeSpeed;
        monsterStateMachine.NavMeshAgent.gameObject.GetComponent<LookAtConstraint>().constraintActive = true;
        SetFleeDestination(monsterStateMachine);
    }

    public override void Action(StateMachine stateMachine)
    {
        currentStunBuffer += Time.deltaTime;

        if (currentStunBuffer >= stunBufferSeconds)
        {
            stateMachine.NavMeshAgent.gameObject.GetComponent<LookAtConstraint>().constraintActive = false;
            stateMachine.SwitchState(stateMachine.AllStates[(int)SubjectAlphaStates.PatrolState]);
        }

        else
        {
            SetFleeDestination(stateMachine);
            IsRestunned(stateMachine);
        }
    }
}
