using UnityEngine;
using UnityEngine.AI;

public class SubjectBetaBehaviour : MonoBehaviour
{
    [Range(0.75f, 0.25f)]
    [SerializeField] private float investigationRange;
    [Range(2f, 0.75f)]
    [SerializeField] private float aggroRange;
    [SerializeField] private RoamState roamState;
    [SerializeField] private InvestigateState investigateState;
    [SerializeField] private SniffState sniffState;
    [SerializeField] private AggroState aggroState;
    private PlayerSound playerSound;

    public StateMachine StateMachine { get; private set; }
    public RoamState RoamState { get => this.roamState; set => this.roamState = value; }
    public InvestigateState InvestigateState { get => this.investigateState; set => this.investigateState = value; }
    public SniffState SniffState { get => this.sniffState; set => this.sniffState = value; }
    public AggroState AggroState { get => this.aggroState; set => this.aggroState = value; }

    private StateMachine InitializeStateMachine()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        State[] allStates = new State[4];
        allStates[0] = RoamState;
        allStates[1] = InvestigateState;
        allStates[2] = SniffState;
        allStates[3] = AggroState;
        return new StateMachine(player, navMeshAgent, allStates, RoamState);
    }

    private void MonsterHearing(float soundLoudness, Vector3 soundPosition)
    {
        float distanceFromSource = (StateMachine.NavMeshAgent.transform.position - soundPosition).magnitude;

        if (soundLoudness / distanceFromSource >= aggroRange)
        {
            StateMachine.SwitchState(StateMachine.AllStates[(int)SubjectBetaStates.AggroState]);
        }

        else if (soundLoudness / distanceFromSource >= investigationRange)
        {
            StateMachine.NavMeshAgent.destination = soundPosition;
            StateMachine.SwitchState(StateMachine.AllStates[(int)SubjectBetaStates.InvestigateState]);
        }
    }

    private void Awake()
    {
        StateMachine = InitializeStateMachine();
        playerSound = GameObject.FindWithTag("Player").GetComponent<PlayerSound>();
        playerSound.MakeSoundEvent += MonsterHearing;
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

public enum SubjectBetaStates
{
    RoamState,
    InvestigateState,
    SniffState,
    AggroState
}
