using System;
using UnityEngine;

[Serializable]
public class SniffState : State
{
    [SerializeField] private float sniffTime;
    private float currentSniffTime;

    public override void Action(StateMachine stateMachine)
    {
        currentSniffTime += Time.deltaTime;

        if (currentSniffTime >= sniffTime)
        {
            stateMachine.SwitchState(stateMachine.AllStates[(int)SubjectBetaStates.RoamState]);
        }
    }

    public override void EnterState(StateMachine stateMachine)
    {
        currentSniffTime = 0f;
    }
}
