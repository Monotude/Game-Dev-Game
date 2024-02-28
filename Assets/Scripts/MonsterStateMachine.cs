using UnityEngine;
using UnityEngine.AI;

public class MonsterStateMachine : MonoBehaviour
{
    [SerializeField] private PatrolState patrolState;
    [SerializeField] private IdleState idleState;
    [SerializeField] private ChaseState chaseState;

    public Transform Player { get; private set; }
    public NavMeshAgent NavMeshAgent { get; private set; }
    public PatrolState PatrolState { get => this.patrolState; set => this.patrolState = value; }
    public IdleState IdleState { get => this.idleState; set => this.idleState = value; }
    public ChaseState ChaseState { get => this.chaseState; set => this.chaseState = value; }
    public MonsterState CurrentMonsterState { get; set; }

    public void SwitchState(MonsterState monsterState)
    {
        CurrentMonsterState = monsterState;
        CurrentMonsterState.EnterState(this);
    }

    private void Start()
    {
        Player = GameObject.Find("Player").transform;
        NavMeshAgent = GetComponent<NavMeshAgent>();
        ChaseState.ResetCurrentTimeUntilChase();
        SwitchState(PatrolState);
    }

    private void Update()
    {
        CurrentMonsterState.Action(this);
    }
}
