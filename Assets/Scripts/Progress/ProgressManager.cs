using System;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private int fuseCount;
    [SerializeField] private Transform player;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private GameObject monster1;
    [SerializeField] private GameObject monster2;

    public int FuseCount { get => this.fuseCount; set => this.fuseCount = value; }
    public Progress Progress { get; set; }
    public event Action LoadGameEvent;
    public event Action PowerOnEvent;

    public void CheckSpawnMonster1()
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
            monster1.SetActive(true);
            StateMachine stateMachine = monster1.GetComponent<Monster1Behaviour>().StateMachine;
            stateMachine.SwitchState(stateMachine.AllStates[(int)Monster1States.ChaseState]);
        }
    }

    public void CheckClearSection1()
    {
        for (int i = 1; i <= fuseCount; ++i)
        {
            if (!Progress.IsElectricalBoxOn(i))
            {
                return;
            }
        }

        RenderSettings.ambientLight = new Color32(53, 53, 53, 0);
        PowerOnEvent?.Invoke();
        Destroy(monster1);
        AudioManager.Instance.StopMusic();
    }

    private void LoadMonster1()
    {
        for (int i = 1; i <= fuseCount; ++i)
        {
            if (Progress.IsFuseCollected(i))
            {
                return;
            }
        }

        monster1.SetActive(false);
    }

    public void StartSection2()
    {
        monster2.SetActive(true);
    }

    public void ClearSection2()
    {
        RenderSettings.ambientLight = new Color32(53, 53, 53, 0);
        Destroy(monster2);
        AudioManager.Instance.StopMusic();
    }

    private void LoadPlayerStart()
    {
        Vector3 startPosition = new Vector3(4.12f, 1f, 59.16f);

        if (Progress.GetIsLoreRoomOpen())
        {
            startPosition = new Vector3(71f, -2f, 67f);
        }

        else if (Progress.GetIsSection2Started())
        {
            startPosition = new Vector3(84f, 1f, 58f);
        }

        TeleportPlayer(startPosition);
    }

    private void TeleportPlayer(Vector3 position)
    {
        player.GetComponent<Rigidbody>().MovePosition(position);
        mainCamera.position = position + new Vector3(0, 0.5f, 0);
    }

    private void Start()
    {
        AudioManager.Instance.PlayMusic("Section 1 Horror");
        SaveManager.Instance.LoadProgress();
        LoadGameEvent += LoadPlayerStart;
        LoadGameEvent += LoadMonster1;
        LoadGameEvent += CheckClearSection1;
        LoadGameEvent?.Invoke();
    }
}
