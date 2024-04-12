using System;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private int fuseCount;
    [SerializeField] private GameObject monster;

    public int FuseCount { get => this.fuseCount; set => this.fuseCount = value; }
    public Progress Progress { get; set; }
    public event Action LoadGame;

    public void CheckSpawnMonster()
    {
        bool isAFuseBoxOn = false;
        for (int i = 0; i < FuseCount; ++i)
        {
            if (Progress.IsFuseBoxPowered(i + 1))
            {
                isAFuseBoxOn = true;
                break;
            }
        }

        if (Progress.GetFuseCount() == 1 && !isAFuseBoxOn)
        {
            monster.SetActive(true);
            StateMachine stateMachine = monster.GetComponent<Monster1Behaviour>().StateMachine;
            stateMachine.SwitchState(stateMachine.AllStates[(int)Monster1States.ChaseState]);
        }
    }

    public void CheckTurnLightsOn()
    {
        for (int i = 1; i <= fuseCount; ++i)
        {
            if (!Progress.IsElectricalBoxOn(i))
            {
                return;
            }
        }

        RenderSettings.ambientLight = new Color32(53, 53, 53, 0);
        Destroy(monster);
        AudioManager.Instance.StopMusic();
    }

    private void LoadMonster()
    {
        for (int i = 1; i <= fuseCount; ++i)
        {
            if (Progress.IsFuseCollected(i))
            {
                return;
            }
        }

        monster.SetActive(false);
    }

    private void Start()
    {
        AudioManager.Instance.PlayMusic("Section 1 Horror");
        SaveManager.Instance.LoadProgress();
        LoadGame += LoadMonster;
        LoadGame += CheckTurnLightsOn;
        LoadGame?.Invoke();
    }
}
