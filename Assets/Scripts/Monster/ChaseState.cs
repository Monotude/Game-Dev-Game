using System;
using UnityEngine;

[Serializable]
public class ChaseState : MonsterState
{
    [SerializeField] private Light uVLightLight;
    [SerializeField] private PlayerUVLight playerUVLight;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private int minTimeUntilChase;
    [SerializeField] private int maxTimeUntilChase;
    [SerializeField] private float timeUntilChase;

    public float CurrentTimeUntilChase { get; private set; }
    public float TimeUntilChase { get => this.timeUntilChase; set => this.timeUntilChase = value; }

    public void ResetCurrentTimeUntilChase()
    {
        CurrentTimeUntilChase = TimeUntilChase = UnityEngine.Random.Range(minTimeUntilChase, maxTimeUntilChase);
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
        ResetCurrentTimeUntilChase();
        monsterStateMachine.NavMeshAgent.speed = chaseSpeed;
        monsterStateMachine.NavMeshAgent.destination = monsterStateMachine.Player.position;
    }

    public override void Action(MonsterStateMachine monsterStateMachine)
    {
        monsterStateMachine.NavMeshAgent.destination = monsterStateMachine.Player.position;

        if (IsStunned(monsterStateMachine))
        {
            monsterStateMachine.SwitchState(monsterStateMachine.FleeState);
        }
    }
}
