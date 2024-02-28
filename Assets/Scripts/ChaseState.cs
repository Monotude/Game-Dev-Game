using System;
using UnityEngine;

[Serializable]
public class ChaseState : MonsterState
{
    [SerializeField] private Transform player;
    [SerializeField] private Light uVLight;
    [SerializeField] private PlayerUVLight playerUVLight;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float timeUntilChase;

    public float CurrentTimeUntilChase { get; private set; }
    public float TimeUntilChase { get => this.timeUntilChase; set => this.timeUntilChase = value; }

    public void ResetCurrentTimeUntilChase()
    {
        CurrentTimeUntilChase = TimeUntilChase;
    }

    public bool IsTimeToChase()
    {
        CurrentTimeUntilChase -= Time.deltaTime;
        return CurrentTimeUntilChase <= 0;
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
        bool lookingAtMonsterDirection = 0.91f < angle;

        if (!lookingAtMonsterDirection)
        {
            return false;
        }

        Vector3 playerToMonster = monster.position - player.position;
        Ray ray = new Ray(player.position, playerToMonster);
        Physics.Raycast(ray, out RaycastHit hit, uVLight.range);

        return hit.transform == monster;
    }

    public override void EnterState(MonsterStateMachine monsterStateMachine)
    {
        ResetCurrentTimeUntilChase();
        monsterStateMachine.NavMeshAgent.speed = chaseSpeed;
        monsterStateMachine.NavMeshAgent.destination = player.position;
    }

    public override void Action(MonsterStateMachine monsterStateMachine)
    {
        monsterStateMachine.NavMeshAgent.destination = player.position;

        if (IsStunned(monsterStateMachine))
        {
            monsterStateMachine.SwitchState(monsterStateMachine.PatrolState);
        }
    }
}
