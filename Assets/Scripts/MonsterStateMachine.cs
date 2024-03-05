using System;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStateMachine : MonoBehaviour
{
    [SerializeField] private ChaseState chaseState;
    [SerializeField] private FleeState fleeState;
    [SerializeField] private PatrolState patrolState;
    [SerializeField] private IdleState idleState;

    public Transform Player { get; private set; }
    public NavMeshAgent NavMeshAgent { get; private set; }
    public ChaseState ChaseState { get => this.chaseState; set => this.chaseState = value; }
    public FleeState FleeState { get => this.fleeState; set => this.fleeState = value; }
    public PatrolState PatrolState { get => this.patrolState; set => this.patrolState = value; }
    public IdleState IdleState { get => this.idleState; set => this.idleState = value; }
    public MonsterState CurrentMonsterState { get; private set; }
    public event Action<MonsterState> ChangeMonsterState;

    public void SwitchState(MonsterState monsterState)
    {
        CurrentMonsterState = monsterState;
        ChangeMonsterState?.Invoke(monsterState);
        CurrentMonsterState.EnterState(this);
    }

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
        NavMeshAgent = GetComponent<NavMeshAgent>();
        SwitchState(ChaseState);
    }

    private void Update()
    {
        CurrentMonsterState.Action(this);
    }
}
