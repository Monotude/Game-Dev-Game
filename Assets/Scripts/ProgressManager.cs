using System;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private bool isPowerOn;
    [SerializeField] private int fuseCount;
    [SerializeField] private GameObject monster;

    public int FuseCount { get => this.fuseCount; set => this.fuseCount = value; }
    public Progress Progress { get; set; }
    public event Action LoadGame;

    public void CheckSpawnMonster()
    {
        int fuseCollected = 0;
        for (int i = 1; i <= fuseCount; ++i)
        {
            if (Progress.IsFuseCollected(i))
            {
                ++fuseCollected;
            }
        }

        if (fuseCollected == 1)
        {
            monster.SetActive(true);
            MonsterStateMachine monsterStateMachine = monster.GetComponent<MonsterStateMachine>();
            monsterStateMachine.SwitchState(monsterStateMachine.ChaseState);
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

        isPowerOn = true;
        RenderSettings.ambientLight = new Color32(55, 55, 55, 0);
        Destroy(monster);
        AudioManager.Instance.StopMusic();
    }

    private void LoadMonster()
    {
        for (int i = 1; i <= fuseCount; ++i)
        {
            if (Progress.IsFuseCollected(i))
            {
                monster.SetActive(true);
            }
        }
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
