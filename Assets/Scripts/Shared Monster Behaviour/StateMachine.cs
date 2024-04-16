using System;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine
{
    public Transform Player { get; private set; }
    public NavMeshAgent NavMeshAgent { get; private set; }
    public State[] AllStates;
    public State CurrentState { get; private set; }
    public event Action<State> ChangeStateEvent;

    public StateMachine(Transform player, NavMeshAgent navMeshAgent, State[] allStates, State currentState)
    {
        Player = player;
        NavMeshAgent = navMeshAgent;
        this.AllStates = allStates;
        SwitchState(currentState);
    }

    public void SwitchState(State state)
    {
        CurrentState = state;
        ChangeStateEvent?.Invoke(state);
        CurrentState.EnterState(this);
    }
}
