using System;
using UnityEngine;
using UnityEngine.Animations;

[Serializable]
public class FleeState : MonsterState
{
    private float currentStunBuffer;
    [SerializeField] private Light uVLightLight;
    [SerializeField] private PlayerUVLight playerUVLight;
    [Range(0f, 1f)]
    [SerializeField] private float stoppingSpeed; // 0 stops fast, 1 stops slow
    [SerializeField] private float stunBufferSeconds;
    [SerializeField] private float fleeSpeed;

    private Vector3 GetFleeDestination(Transform monster)
    {
        Physics.Raycast(monster.position, -monster.forward, out RaycastHit hit);
        return hit.point;
    }

    private void SetFleeDestination(MonsterStateMachine monsterStateMachine)
    {
        monsterStateMachine.NavMeshAgent.destination = GetFleeDestination(monsterStateMachine.transform);
    }

    private void IsRestunned(MonsterStateMachine monsterStateMachine)
    {
        if (IsStunned(monsterStateMachine))
        {
            currentStunBuffer = 0f;
        }
    }

    private bool IsStunned(MonsterStateMachine monsterStateMachine)
    {
        if (!playerUVLight.IsUVLightOn)
        {
            return false;
        }

        Transform camera = Camera.main.transform;
        Transform monster = monsterStateMachine.gameObject.transform;

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

    public override void EnterState(MonsterStateMachine monsterStateMachine)
    {
        currentStunBuffer = 0f;
        monsterStateMachine.NavMeshAgent.velocity = monsterStateMachine.NavMeshAgent.velocity * stoppingSpeed;
        monsterStateMachine.NavMeshAgent.speed = fleeSpeed;
        monsterStateMachine.transform.GetComponent<LookAtConstraint>().constraintActive = true;
        SetFleeDestination(monsterStateMachine);
    }

    public override void Action(MonsterStateMachine monsterStateMachine)
    {
        currentStunBuffer += Time.deltaTime;

        if (currentStunBuffer >= stunBufferSeconds)
        {
            monsterStateMachine.transform.GetComponent<LookAtConstraint>().constraintActive = false;
            monsterStateMachine.SwitchState(monsterStateMachine.PatrolState);
        }

        else
        {
            SetFleeDestination(monsterStateMachine);
            IsRestunned(monsterStateMachine);
        }
    }
}
