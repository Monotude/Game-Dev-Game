using System;
using UnityEngine;

[Serializable]
public class ChaseState : State
{
    [SerializeField] private Light uVLightLight;
    [SerializeField] private PlayerUVLight playerUVLight;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private int minTimeUntilChase;
    [SerializeField] private int maxTimeUntilChase;
    private float timeUntilChase;

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

    private bool IsStunned(StateMachine stateMachine)
    {
        if (!playerUVLight.IsUVLightOn)
        {
            return false;
        }

        Transform camera = Camera.main.transform;
        Transform monster = stateMachine.NavMeshAgent.transform;

        Vector3 cameraToMonster = monster.position - camera.position;
        float angle = Vector3.Dot(camera.forward, cameraToMonster);
        bool lookingAtMonsterDirection = Mathf.Cos(Mathf.Deg2Rad * uVLightLight.innerSpotAngle / 2) <= angle;

        if (!lookingAtMonsterDirection)
        {
            return false;
        }

        Transform player = stateMachine.Player;

        Vector3 playerToMonster = monster.position - player.position;
        Ray ray = new Ray(player.position, playerToMonster);
        Physics.Raycast(ray, out RaycastHit hit, uVLightLight.range);

        return hit.transform == monster;
    }

    public override void EnterState(StateMachine stateMachine)
    {
        ResetCurrentTimeUntilChase();
        stateMachine.NavMeshAgent.speed = chaseSpeed;
        stateMachine.NavMeshAgent.destination = stateMachine.Player.position;
    }

    public override void Action(StateMachine stateMachine)
    {
        stateMachine.NavMeshAgent.destination = stateMachine.Player.position;

        if (IsStunned(stateMachine))
        {
            stateMachine.SwitchState(stateMachine.AllStates[(int)SubjectAlphaStates.FleeState]);
        }
    }
}
