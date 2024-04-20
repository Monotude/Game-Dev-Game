using UnityEngine;
using UnityEngine.AI;

public class SubjectAlphaBehaviour : MonoBehaviour
{
    [SerializeField] private ChaseState chaseState;
    [SerializeField] private FleeState fleeState;
    [SerializeField] private PatrolState patrolState;
    [SerializeField] private IdleState idleState;

    public StateMachine StateMachine { get; private set; }
    public ChaseState ChaseState { get => this.chaseState; set => this.chaseState = value; }
    public FleeState FleeState { get => this.fleeState; set => this.fleeState = value; }
    public PatrolState PatrolState { get => this.patrolState; set => this.patrolState = value; }
    public IdleState IdleState { get => this.idleState; set => this.idleState = value; }

    private StateMachine InitializeStateMachine()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        State[] allStates = new State[4];
        allStates[0] = ChaseState;
        ChaseState.ResetCurrentTimeUntilChase();
        allStates[1] = FleeState;
        allStates[2] = PatrolState;
        allStates[3] = IdleState;
        return new StateMachine(player, navMeshAgent, allStates, PatrolState);
    }

    private void Awake()
    {
        StateMachine = InitializeStateMachine();
    }

    private void OnEnable()
    {
        StateMachine.SwitchState(StateMachine.CurrentState);
    }

    private void Update()
    {
        StateMachine.CurrentState.Action(StateMachine);
    }
}

public enum SubjectAlphaStates
{
    ChaseState,
    FleeState,
    PatrolState,
    IdleState
}
