using UnityEngine;
using UnityEngine.AI;

public class Monster2Behaviour : MonoBehaviour
{
    [Range(0.75f, 0.25f)]
    [SerializeField] private float investigationRange;
    [Range(2f, 0.75f)]
    [SerializeField] private float aggroRange;
    [SerializeField] private RoamState roamState;
    [SerializeField] private InvestigateState investigateState;
    [SerializeField] private AggroState aggroState;
    private PlayerSound playerSound;

    public StateMachine StateMachine { get; private set; }
    public RoamState RoamState { get => this.roamState; set => this.roamState = value; }
    public InvestigateState InvestigateState { get => this.investigateState; set => this.investigateState = value; }
    public AggroState AggroState { get => this.aggroState; set => this.aggroState = value; }

    private StateMachine InitializeStateMachine()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        State[] allStates = new State[3];
        allStates[0] = RoamState;
        allStates[1] = InvestigateState;
        allStates[2] = AggroState;
        return new StateMachine(player, navMeshAgent, allStates, RoamState);
    }

    private void MonsterHearing(float soundLoudness, Vector3 position)
    {
        float distanceFromSource = (StateMachine.NavMeshAgent.transform.position - position).magnitude;

        if (soundLoudness / distanceFromSource >= aggroRange)
        {
            StateMachine.SwitchState(StateMachine.AllStates[(int)Monster2States.AggroState]);
        }

        else if (soundLoudness / distanceFromSource >= investigationRange)
        {
            StateMachine.SwitchState(StateMachine.AllStates[(int)Monster2States.InvestigateState]);
        }
    }

    private void Awake()
    {
        StateMachine = InitializeStateMachine();
        playerSound = GameObject.FindWithTag("Player").GetComponent<PlayerSound>();
        playerSound.MakeSoundEvent += MonsterHearing;
    }

    private void Update()
    {
        StateMachine.CurrentState.Action(StateMachine);
    }
}

public enum Monster2States
{
    RoamState,
    InvestigateState,
    AggroState
}
